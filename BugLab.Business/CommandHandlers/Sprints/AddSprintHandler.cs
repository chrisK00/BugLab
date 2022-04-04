using BugLab.Business.Commands.Sprints;
using BugLab.Data;
using BugLab.Data.Entities;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Sprints
{
    public class AddSprintHandler : IRequestHandler<AddSprintCommand, int>
    {
        private readonly AppDbContext _context;

        public AddSprintHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddSprintCommand request, CancellationToken cancellationToken)
        {
            var newSprint = request.Adapt<Sprint>();
            await _context.AddAsync(newSprint, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newSprint.Id;
        }
    }
}
