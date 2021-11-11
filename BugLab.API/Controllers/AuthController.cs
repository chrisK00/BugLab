using BugLab.Shared.Commands;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(command, cancellationToken);

            return user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
