using BugLab.Business.Interfaces;
using BugLab.Business.Options;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BugLab.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;
        private readonly ClientOptions _clientOptions;

        public EmailService(IOptions<EmailOptions> emailOptions, IOptions<ClientOptions> clientOptions)
        {
            _emailOptions = emailOptions.Value;
            _clientOptions = clientOptions.Value;
        }

        public async Task SendAsync(string subject, string body, string to)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailOptions.Name, _emailOptions.From));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync(_emailOptions.Host, _emailOptions.Port);
            await client.AuthenticateAsync(_emailOptions.From, _emailOptions.Password);
            await client.SendAsync(message);
        }

        public async Task SendEmailConfirmationAsync(string confirmationToken, string userId, string to)
        {
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

            var template = await File.ReadAllTextAsync(@"Assets\email-template.html");
            var link = $"{_clientOptions.Uri}/confirm-email/{userId}/token/{encodedToken}";
            var body = template.Replace("{link}", link);

            await SendAsync("Confirm your email", body, to);
        }
    }
}
