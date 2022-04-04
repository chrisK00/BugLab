using BugLab.Business.Commands.Sprints;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.Sprints;
using BugLab.Data.Extensions;
using BugLab.Shared.Requests.Sprints;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/projects/{projectId}/[controller]")]
    public class SprintsController : BaseApiController
    {
        private readonly IAuthService _authService;

        public SprintsController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SprintForListResponse>>> GetSprints(int projectId, CancellationToken cancellationToken)
        {
            var sprints = await _mediator.Send(new GetSprintsQuery(projectId), cancellationToken);

            return Ok(sprints);
        }

        [HttpGet("{id}", Name = nameof(GetSprint))]
        public async Task<ActionResult<SprintDetailsResponse>> GetSprint(int id, CancellationToken cancellationToken)
        {
            var sprint = await _mediator.Send(new GetSprintQuery(id), cancellationToken);

            return Ok(sprint);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SprintDetailsResponse>> DeleteSprint(int projectId, int id, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new DeleteSprintCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddSprint(int projectId, AddSprintRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            var command = new AddSprintCommand(projectId, request.Title, request.StartDate, request.EndDate);
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetSprint), new { projectId, id }, id);
        }
    }
}
