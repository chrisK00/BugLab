using BugLab.API.Extensions;
using BugLab.Business.Interfaces;
using BugLab.Data.Extensions;
using BugLab.Shared.Commands;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects([FromQuery] GetProjectsQuery query, CancellationToken cancellationToken)
        {
            var projects = await _mediator.Send(query, cancellationToken);
            Response.AddPaginationHeader(projects.PageNumber, projects.PageSize, projects.TotalPages, projects.TotalItems);

            return projects;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectCommand command, CancellationToken cancellationToken)
        {
            command.UserId = User.UserId();
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetProject), new { id }, id);
        }

        [HttpPost("{projectId}/add-users")]
        public async Task<IActionResult> AddUsersToProject(int projectId, [FromQuery] IEnumerable<string> userIds, CancellationToken cancellationToken)
        {
            if (!userIds.Any()) return BadRequest("You need to specify at least 1 user to add");
            await _projectAuthService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new AddProjectUsersCommand { UserIds = userIds, ProjectId = projectId }, cancellationToken);

            return NoContent();
        }
    }
}