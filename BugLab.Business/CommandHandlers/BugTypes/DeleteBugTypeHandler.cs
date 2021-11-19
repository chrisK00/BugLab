using BugLab.Business.Commands.BugTypes;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.BugTypes
{
    public class DeleteBugTypeHandler : IRequestHandler<DeleteBugTypeCommand>
    {
        private readonly AppDbContext _context;

        public DeleteBugTypeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBugTypeCommand request, CancellationToken cancellationToken)
        {
            var bugType = await _context.BugTypes.FirstOrDefaultAsync(bt => bt.Id == request.Id, cancellationToken);
            Guard.NotFound(bugType, "bug type", request.Id);

            var hasRelatedBugs = await _context.Bugs.AnyAsync(b => b.BugTypeId == request.Id, cancellationToken);
            if (hasRelatedBugs) throw new InvalidOperationException("You can't delete a bug type that is being used by other bugs");

            _context.BugTypes.Remove(bugType);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
