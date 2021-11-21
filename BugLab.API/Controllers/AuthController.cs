using BugLab.Business.Commands.Auth;
using BugLab.Shared.Requests.Auth;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(request.Adapt<LoginCommand>(), cancellationToken);

            return user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request.Adapt<RegisterCommand>(), cancellationToken);

            return NoContent();
        }

        [HttpGet("{userId}/confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, string userId)
        {
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Invalid Confirmation Token");

            await _mediator.Send(new ConfirmEmailCommand(userId, token));

            return Ok("Email confirmed");
        }
    }
}
