using BugLab.Business.Commands.Bugs;
using BugLab.Data;
using BugLab.Data.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Bugs
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
            var newBug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = request.Status,
                ProjectId = request.ProjectId,
                BugTypeId = request.TypeId,
                AssignedToId = string.IsNullOrWhiteSpace(request.AssignedToId) ? null : request.AssignedToId,
            };

            await _context.Bugs.AddAsync(newBug, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newBug.Id;
        }
    }
}
