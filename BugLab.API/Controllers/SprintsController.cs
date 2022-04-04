using BugLab.Business.Commands.Sprints;
using BugLab.Business.Interfaces;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SprintResponse>>> GetSprints(int projectId, CancellationToken cancellationToken)
        {
            var sprint = await _mediator.Send(new GetSprintsQuery(projectId), cancellationToken);

            return Ok(sprint);
        }

        [HttpPost]
        public async Task<IActionResult> AddSprint(int projectId, UpsertSprintRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            var id = await _mediator.Send(request.Adapt<AddSprintCommand>(), cancellationToken);

            return Ok(id);
            // TODO: add getmethod
            //return CreatedAtRoute(nameof(GetSprint), new { projectId, id }, id);
        }
    }
}
