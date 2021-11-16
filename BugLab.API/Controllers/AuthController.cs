using BugLab.Business.Commands.Auth;
using BugLab.Shared.Auth.Requests;
using BugLab.Shared.Responses;
using Mapster;
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
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(request.Adapt<LoginCommand>(), cancellationToken);

            return user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request.Adapt<RegisterCommand>(), cancellationToken);

            return NoContent();
        }
    }
}
