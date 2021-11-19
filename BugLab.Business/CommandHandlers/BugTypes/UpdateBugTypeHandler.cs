using BugLab.Business.Commands.BugTypes;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.BugTypes
{
    public class UpdateBugTypeHandler : IRequestHandler<UpdateBugTypeCommand>
    {

        private readonly AppDbContext _context;

        public UpdateBugTypeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBugTypeCommand request, CancellationToken cancellationToken)
        {
            var bugType = await _context.BugTypes.FirstOrDefaultAsync(bt => bt.Id == request.Id, cancellationToken);
            Guard.NotFound(bugType, "bug type", request.Id);

            bugType.Title = request.Title;
            bugType.Color = request.Color;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
