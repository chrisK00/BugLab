using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Commands;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers
{
    public class AddBugHandler : IRequestHandler<AddBugCommand, int>
    {
        private readonly AppDbContext _context;

        public AddBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddBugCommand request, CancellationToken cancellationToken)
        {
            var newBug = request.Adapt<Bug>(); 
            await _context.Bugs.AddAsync(newBug, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newBug.Id;
        }
    }
}
