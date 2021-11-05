using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Commands;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class AddProjectHandler : IRequestHandler<AddProjectCommand, int>
    {
        private readonly AppDbContext _context;

        public AddProjectHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectToAdd = request.Adapt<Project>();
            await _context.AddAsync(projectToAdd, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return projectToAdd.Id;
        }
    }
}
