using BugLab.Business.Commands.Projects;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly AppDbContext _context;

        public DeleteProjectHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            Guard.NotFound(project, nameof(project), request.Id);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
