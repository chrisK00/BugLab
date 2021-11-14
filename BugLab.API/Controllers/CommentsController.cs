using BugLab.Business.Interfaces;
using BugLab.Data.Extensions;
using BugLab.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    [Route("api/bugs/{bugId}/[controller]")]
    public class CommentsController : BaseApiController
    {
        private readonly IAuthService _authService;

        public CommentsController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentCommand command, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), command.BugId);

            await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = command.BugId }, new { command.BugId });
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int bugId, int commentId, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), bugId);
            await _mediator.Send(new DeleteCommentCommand(bugId, commentId), cancellationToken);

            return NoContent();
        }
    }
}
