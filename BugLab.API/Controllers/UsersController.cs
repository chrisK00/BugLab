using BugLab.API.Extensions;
using BugLab.Business.Helpers;
using BugLab.Business.Queries.Users;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using Mapster;
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
        public async Task<ActionResult<PagedList<UserResponse>>> GetUsers([FromQuery] UserParams queryParams, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(queryParams.Adapt<GetUsersQuery>(), cancellationToken);
            Response.AddPaginationHeader(users.PageNumber, users.PageSize, users.TotalPages, users.TotalItems);

            return users;
        }
    }
}
