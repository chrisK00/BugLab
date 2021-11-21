using System.Threading.Tasks;

namespace BugLab.Business.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string subject, string body, string to);
        Task SendEmailConfirmationAsync(string confirmationToken, string userId, string to);
    }
}
