using BugLab.API.Extensions;
using BugLab.Shared.Commands;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class BugsController : BaseApiController
    {
        public BugsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = nameof(GetBug))]
        public async Task<ActionResult<BugResponse>> GetBug(int id, CancellationToken cancellationToken)
        {
            var bug = await _mediator.Send(new GetBugQuery(id), cancellationToken);
            return bug;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugResponse>>> GetBugs([FromQuery] GetBugsQuery query, CancellationToken cancellationToken)
        {
            var bugs = await _mediator.Send(query, cancellationToken);
            Response.AddPaginationHeader(bugs.PageNumber, bugs.PageSize, bugs.TotalPages, bugs.TotalItems);

            return Ok(bugs);
        }

        [HttpPost]
        public async Task<IActionResult> AddBug(AddBugCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(GetBug), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBug(UpdateBugCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
