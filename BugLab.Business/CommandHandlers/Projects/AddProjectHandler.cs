using BugLab.Business.Commands.Projects;
using BugLab.Data;
using BugLab.Data.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var user = await _context.Users.FirstAsync(x => x.Id == request.UserId, cancellationToken);
            var projectToAdd = request.Adapt<Project>();

            projectToAdd.Users.Add(user);
            await _context.Projects.AddAsync(projectToAdd, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _context.BugTypes.AddRangeAsync(
                new BugType { ProjectId = projectToAdd.Id, Title = "refactor", Color = "#977FE4" },
                new BugType { ProjectId = projectToAdd.Id, Title = "bug", Color = "#b14639ff" },
                new BugType { ProjectId = projectToAdd.Id, Title = "feature", Color = "#35ceceff" }
                );
            await _context.SaveChangesAsync(cancellationToken);

            return projectToAdd.Id;
        }
    }
}
