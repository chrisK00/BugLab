using BugLab.API.Extensions;
using BugLab.Business.Commands.Projects;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.Projects;
using BugLab.Data.Extensions;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Requests.Projects;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IAuthService _projectAuthService;

        public ProjectsController(IMediator mediator, IAuthService projectAuthService) : base(mediator)
        {
            _projectAuthService = projectAuthService;
        }

        [HttpGet("{id}", Name = nameof(GetProject))]
        public async Task<ActionResult<ProjectResponse>> GetProject(int id, CancellationToken cancellationToken)
        {
            var project = await _mediator.Send(new GetProjectQuery(id), cancellationToken);

            return project;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects([FromQuery] PaginationParams queryParams, CancellationToken cancellationToken)
        {
            var query = new GetProjectsQuery(User.UserId());
            queryParams.Adapt(query);
            var projects = await _mediator.Send(query, cancellationToken);
            Response.AddPaginationHeader(projects.PageNumber, projects.PageSize, projects.TotalPages, projects.TotalItems);

            return projects;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectRequest request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new AddProjectCommand(User.UserId(), request.Title, request.Description), cancellationToken);

            return CreatedAtRoute(nameof(GetProject), new { id }, id);
        }

        [HttpPost("{projectId}/add-users")]
        public async Task<IActionResult> AddUsersToProject(int projectId, [FromQuery] IEnumerable<string> userIds, CancellationToken cancellationToken)
        {
            if (!userIds.Any()) return NoContent();

            await _projectAuthService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new AddProjectUsersCommand(projectId, userIds), cancellationToken);

            return NoContent();
        }
    }
}