using BugLab.Business.Commands.Projects;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var projectUser = await _context.ProjectUsers.FirstOrDefaultAsync(pu => pu.ProjectId == request.ProjectId && pu.UserId == request.UserId, cancellationToken);
            Guard.NotFound(projectUser, "user", request.UserId);

            _context.ProjectUsers.Remove(projectUser);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
