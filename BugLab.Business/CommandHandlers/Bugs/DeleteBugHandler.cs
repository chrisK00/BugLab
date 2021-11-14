using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Bugs
{
    public class DeleteBugHandler : IRequestHandler<DeleteBugCommand>
    {
        private readonly AppDbContext _context;

        public DeleteBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.Id);

            bug.Deleted = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
