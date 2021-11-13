using BugLab.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class RegisterHandler : IRequestHandler<RegisterCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerResult = await _userManager.CreateAsync(new IdentityUser { Email = request.Email, UserName = request.Email }, request.Password);
            if (registerResult.Succeeded) return Unit.Value;

            var sb = new StringBuilder();

            foreach (var error in registerResult.Errors)
            {
                sb.Append(error.Description);
            }

            throw new InvalidOperationException(sb.ToString());
        }
    }
}
