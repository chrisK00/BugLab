using BugLab.Shared.Commands;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class BugsController : BaseApiController
    {
        public BugsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = nameof(Get))]
        public async Task<ActionResult<BugResponse>> Get(int id, CancellationToken cancellationToken)
        {
            var bug = await _mediator.Send(new GetBugQuery(id), cancellationToken);
            return bug;
        }

        [HttpPost]
        public async Task<IActionResult> AddBug(AddBugCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(Get), new { id }, id);
        }
    }
}
