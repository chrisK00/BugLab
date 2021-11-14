using BugLab.Shared.Queries;
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
        public BugTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugTypeResponse>>> GetBugTypes(int projectId, CancellationToken cancellationToken)
        {
            var bugTypes = await _mediator.Send(new GetBugTypesQuery(projectId), cancellationToken);

            return Ok(bugTypes);
        }
    }
}
