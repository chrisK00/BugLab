using BugLab.Business.Commands.Auth;
using BugLab.Business.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class ResendEmailConfirmationHandler : IRequestHandler<ResendEmailConfirmationCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;

        public ResendEmailConfirmationHandler(ITokenService tokenService, UserManager<IdentityUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(ResendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user.EmailConfirmed) throw new InvalidOperationException("You have already confirmed your email");

            await _tokenService.SendEmailConfirmationAsync(user);

            return Unit.Value;
        }
    }
}
