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
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly AppDbContext _context;

        public UpdateCommentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == request.BugId, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.BugId);

            var comment = bug.Comments.FirstOrDefault(c => c.Id == request.Id);
            comment.Text = request.Text;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
