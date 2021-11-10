using BugLab.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/{bugId}/[controller]")]
    public class CommentsController : BaseApiController
    {
        public CommentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(AddCommentCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = command.BugId }, new { command.BugId });
        }
    }
}
