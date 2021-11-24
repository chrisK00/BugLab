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
        private readonly ITokenService _tokenService;

        public RegisterHandler(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
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

            await _tokenService.SendEmailConfirmationAsync(user);

            return Unit.Value;
        }
    }
}
