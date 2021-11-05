using BugLab.Shared.Commands;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        public ProjectsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = nameof(GetProject))]
        public async Task<ActionResult<ProjectResponse>> GetProject(int id, CancellationToken cancellationToken)
        {
            var project = await _mediator.Send(new GetProjectQuery(id), cancellationToken);

            return project;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetProject), new { id }, id);
        }
    }
}
