using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class AddProjectUserHandler : IRequestHandler<AddProjectUserCommand>
    {
        private readonly AppDbContext _context;

        public AddProjectUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddProjectUserCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId, cancellationToken);
            Guard.NotFound(project, nameof(Project), request.ProjectId);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            Guard.NotFound(user, nameof(user), request.UserId);

            if (project.Users.Any(x => x.Id == user.Id))
            {
                return Unit.Value;
            }

            project.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
