using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/[controller]/{refreshToken}")]
    public class TokenController : BaseApiController
    {
        public TokenController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<string>> RefreshToken(string refreshToken)
        {
            return Ok("");
        } 
    }
}
