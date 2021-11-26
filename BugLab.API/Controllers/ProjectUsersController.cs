using BugLab.Business.Commands.Projects;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.Projects;
using BugLab.Data.Extensions;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/projects/{projectId}/[controller]")]
    public class ProjectUsersController : BaseApiController
    {
        private readonly IAuthService _authService;

        public ProjectUsersController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetProjectUsers(int projectId, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetProjectUsersQuery(projectId), cancellationToken);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsersToProject(int projectId, [FromQuery] IEnumerable<string> userIds, CancellationToken cancellationToken)
        {
            if (!userIds.Any()) return NoContent();

            await _authService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new AddProjectUsersCommand(projectId, userIds), cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectUser(int projectId, string id, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new DeleteProjectUserCommand(projectId, id), cancellationToken);

            return NoContent();
        }
    }
}
