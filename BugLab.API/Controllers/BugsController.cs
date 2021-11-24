using BugLab.API.Extensions;
using BugLab.Business.Commands.Bugs;
using BugLab.Business.Interfaces;
using BugLab.Business.Queries.Bugs;
using BugLab.Data.Extensions;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Requests.Bugs;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class BugsController : BaseApiController
    {
        private readonly IAuthService _authService;

        public BugsController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpGet("{id}", Name = nameof(GetBug))]
        public async Task<ActionResult<BugResponse>> GetBug(int id, CancellationToken cancellationToken)
        {
            var bug = await _mediator.Send(new GetBugQuery(id), cancellationToken);

            return bug;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugResponse>>> GetBugs([FromQuery] BugParams queryParams, CancellationToken cancellationToken)
        {
            var query = new GetBugsQuery(User.UserId());

            var bugs = await _mediator.Send(queryParams.Adapt(query), cancellationToken);
            Response.AddPaginationHeader(bugs.PageNumber, bugs.PageSize, bugs.TotalPages, bugs.TotalItems);

            return Ok(bugs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), id);
            await _mediator.Send(new DeleteBugCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddBug(AddBugRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToProject(User.UserId(), request.ProjectId);
            var id = await _mediator.Send(request.Adapt<AddBugCommand>(), cancellationToken);

            return CreatedAtRoute(nameof(GetBug), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBug(int id, UpdateBugRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), id);
            var command = new UpdateBugCommand(id, request.Title, request.Description, request.Priority, request.Status, request.TypeId, request.AssignedToId);
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
