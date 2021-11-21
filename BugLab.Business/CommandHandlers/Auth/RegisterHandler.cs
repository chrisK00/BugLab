using BugLab.Business.Commands.Auth;
using BugLab.Business.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class RegisterHandler : IRequestHandler<RegisterCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _mailService;

        public RegisterHandler(UserManager<IdentityUser> userManager, IEmailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser { Email = request.Email, UserName = request.Email };
            var registerResult = await _userManager.CreateAsync(user, request.Password);

            if (!registerResult.Succeeded)
            {
                var sb = new StringBuilder();

                foreach (var error in registerResult.Errors)
                {
                    sb.Append(error.Description);
                }

                throw new InvalidOperationException(sb.ToString());
            }

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _mailService.SendEmailConfirmationAsync(confirmationToken, user.Id, user.Email);

            return Unit.Value;
        }
    }
}
