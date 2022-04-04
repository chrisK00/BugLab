using BugLab.Business.Commands.Bugs;
using BugLab.Business.Helpers;
using BugLab.Data;
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
            var bug = await _context.Bugs.Include(x => x.AssignedTo).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.Id);

            if (request.PartialUpdate) request.Adapt(bug, new TypeAdapterConfig().Default.IgnoreNullValues(true).Config);
            else request.Adapt(bug);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
