using BugLab.Business.Interfaces;
using BugLab.Data.Extensions;
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
        private readonly IProjectAuthService _projectAuthService;

        public CommentsController(IMediator mediator, IProjectAuthService projectAuthService) : base(mediator)
        {
            _projectAuthService = projectAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(AddCommentCommand command, CancellationToken cancellationToken)
        {
            await _projectAuthService.HasAccess(User.UserId(), command.ProjectId);

            await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = command.BugId }, new { command.BugId });
        }
    }
}
