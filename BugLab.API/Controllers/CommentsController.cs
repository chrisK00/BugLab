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
        private readonly IAuthService _projectAuthService;

        public CommentsController(IMediator mediator, IAuthService projectAuthService) : base(mediator)
        {
            _projectAuthService = projectAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(AddCommentCommand command, CancellationToken cancellationToken)
        {
            await _projectAuthService.HasAccessToProject(User.UserId(), command.ProjectId);

            await _mediator.Send(command, cancellationToken);

            return CreatedAtRoute(nameof(BugsController.GetBug), new { id = command.BugId }, new { command.BugId });
        }
    }
}
