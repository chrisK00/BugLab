using BugLab.Shared.Helpers;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserResponse>>> GetUsers([FromQuery] GetUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(query, cancellationToken);

            return users;
        }
    }
}
