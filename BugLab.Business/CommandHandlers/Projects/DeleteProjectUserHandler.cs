using BugLab.Business.Commands.Projects;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class DeleteProjectUserHandler : IRequestHandler<DeleteProjectUserCommand>
    {
        private readonly AppDbContext _context;

        public DeleteProjectUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectUserCommand request, CancellationToken cancellationToken)
        {
            var projectUsers = await _context.Projects.Where(x => x.Id == request.ProjectId)
                .Select(x => x.Users)
                .FirstOrDefaultAsync(cancellationToken);

            Guard.NotFound(projectUsers, "project", request.ProjectId);
            var userToDelete = projectUsers.FirstOrDefault(u => u.Id == request.UserId);
            Guard.NotFound(userToDelete, "user", request.UserId);

            projectUsers.Remove(userToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
