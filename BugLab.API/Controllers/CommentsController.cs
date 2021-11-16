using BugLab.Business.Commands.Comments;
using BugLab.Business.Interfaces;
using BugLab.Data.Extensions;
using BugLab.Shared.Requests.Comments;
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
        public async Task<IActionResult> AddComment(int bugId, AddCommentRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), bugId);
            await _mediator.Send(new AddCommentCommand(bugId, request.Text), cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = bugId }, new { bugId });
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
