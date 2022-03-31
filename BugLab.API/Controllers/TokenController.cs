using BugLab.Business.Commands.Auth;
using BugLab.Shared.Requests.Auth;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class TokenController : BaseApiController
    {
        public TokenController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<string>> RefreshToken(RefreshTokenRequest request)
        {
            var accessToken = await _mediator.Send(request.Adapt<RefreshTokenCommand>());
            return Ok(accessToken);
        }
    }
}
