﻿using BugLab.Business.Commands.BugTypes;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.BugTypes;
using BugLab.Data.Extensions;
using BugLab.Shared.Requests.BugTypes;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/projects/{projectId}/[controller]")]
    public class BugTypesController : BaseApiController
    {
        private readonly IAuthService _authService;

        public BugTypesController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugTypeResponse>>> GetBugTypes(int projectId, CancellationToken cancellationToken)
        {
            var bugTypes = await _mediator.Send(new GetBugTypesQuery(projectId), cancellationToken);

            return Ok(bugTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddBugType(int projectId, UpsertBugTypeRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            var command = new AddBugTypeCommand(projectId, request.Color, request.Title);
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetBugType), new { projectId, id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBugType(int projectId, int id, UpsertBugTypeRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            var command = new UpdateBugTypeCommand(id, request.Title, request.Color);
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugType(int projectId, int id, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), projectId);
            await _mediator.Send(new DeleteBugTypeCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpGet("{id}", Name = nameof(GetBugType))]
        public async Task<ActionResult<BugTypeResponse>> GetBugType(int id, CancellationToken cancellationToken)
        {
            var bugType = await _mediator.Send(new GetBugTypeQuery(id), cancellationToken);

            return bugType;
        }
    }
}
