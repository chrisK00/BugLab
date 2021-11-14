using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var projectExists = await _context.Projects.AnyAsync(x => x.Id == request.ProjectId, cancellationToken);
            Guard.NotFound(projectExists, nameof(Project), request.ProjectId);

            var newBug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = request.Status,
                ProjectId = request.ProjectId,
                BugTypeId = request.BugTypeId
            };

            await _context.Bugs.AddAsync(newBug, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newBug.Id;
        }
    }
}
