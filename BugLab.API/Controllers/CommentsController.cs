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
        public async Task<IActionResult> AddComment(int bugId, UpsertCommentRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), bugId);
            await _mediator.Send(new AddCommentCommand(bugId, request.Text), cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = bugId }, new { bugId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int bugId, int id, UpsertCommentRequest request, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), bugId);
            await _mediator.Send(new UpdateCommentCommand(id, bugId, request.Text), cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int bugId, int id, CancellationToken cancellationToken)
        {
            await _authService.HasAccessToBug(User.UserId(), bugId);
            await _mediator.Send(new DeleteCommentCommand(id, bugId), cancellationToken);

            return NoContent();
        }
    }
}
