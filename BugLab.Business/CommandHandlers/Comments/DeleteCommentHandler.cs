using BugLab.Business.Commands.Comments;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Comments
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly AppDbContext _context;

        public DeleteCommentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == request.BugId, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.BugId);

            var commentToRemove = bug.Comments.FirstOrDefault(x => x.Id == request.CommentId);
            Guard.NotFound(commentToRemove, "comment", request.CommentId);
            bug.Comments.Remove(commentToRemove);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
