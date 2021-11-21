using BugLab.Business.Commands.Auth;
using BugLab.Business.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmEmailHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            Guard.NotFound(user, nameof(user), request.UserId);

            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.ConfirmationToken));
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (result.Succeeded) return Unit.Value;

            var sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description);
            }

            throw new InvalidOperationException(sb.ToString());
        }
    }
}
