﻿using BugLab.API.Extensions;
using BugLab.Business.Interfaces;
using BugLab.Data.Extensions;
using BugLab.Shared.Commands;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IProjectAuthService _projectAuthService;

        public ProjectsController(IMediator mediator, IProjectAuthService projectAuthService) : base(mediator)
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

        [HttpPost("{projectId}/add-user/{userId}")]
        public async Task<IActionResult> AddUserToProject(int projectId, string userId)
        {
            await _projectAuthService.HasAccess(User.UserId(), projectId);
            await _mediator.Send(new AddProjectUserCommand { UserId = userId, ProjectId = projectId });

            return NoContent();
        }
    }
}