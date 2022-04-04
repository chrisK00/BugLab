using BugLab.Business.Commands.Sprints;
using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Sprints
{
    public class DeleteSprintHandler : IRequestHandler<DeleteSprintCommand>
    {
        private readonly AppDbContext _context;

        public DeleteSprintHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
        {
            var sprint = await _context.Sprints.Include(x => x.Bugs).FirstOrDefaultAsync(x => x.Id == request.Id);
            Guard.NotFound(sprint, nameof(sprint));
 
            _context.Remove(sprint);
            _context.SaveChanges();
            return Unit.Value;
        }
    }

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
