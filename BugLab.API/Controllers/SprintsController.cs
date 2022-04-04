using BugLab.Business.Commands.Sprints;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.Sprints;
using BugLab.Data.Extensions;
using BugLab.Shared.Requests.Sprints;
using BugLab.Shared.Responses;
using Mapster;
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

        [HttpGet(Name = nameof(GetSprints))]
        public async Task<ActionResult<IEnumerable<SprintResponse>>> GetSprints(int projectId, CancellationToken cancellationToken)
        {
            var sprint = await _mediator.Send(new GetSprintsQuery(projectId), cancellationToken);

            return Ok(sprint);
        }

        [HttpPost]
        public async Task<IActionResult> AddSprint(int projectId, UpsertSprintRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            var command = new AddSprintCommand(projectId, request.Title);
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetSprints), new { projectId }, id);
        }
    }
}
