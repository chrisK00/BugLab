using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Commands;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Bugs
{
    public class UpdateBugHandler : IRequestHandler<UpdateBugCommand>
    {
        private readonly AppDbContext _context;

        public UpdateBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            Guard.NotFound(bug, nameof(Bug), request.Id);

            bug.Title = request.Title;
            bug.Status = request.Status;
            bug.Priority = request.Priority;
            bug.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
