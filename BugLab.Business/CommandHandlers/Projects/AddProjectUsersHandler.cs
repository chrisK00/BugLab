using BugLab.Business.Commands.Projects;
using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class AddProjectUsersHandler : IRequestHandler<AddProjectUsersCommand>
    {
        private readonly AppDbContext _context;

        public AddProjectUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddProjectUsersCommand request, CancellationToken cancellationToken)
        {
            var projectUsers = await _context.ProjectUsers.Where(x => x.ProjectId == request.ProjectId).ToListAsync(cancellationToken);

            Guard.NotFound(projectUsers, "project", request.ProjectId);

            var users = await _context.Users.Where(u => request.UserIds.Contains(u.Id)).ToListAsync(cancellationToken);
            Guard.NotFound(users, nameof(users));

            IReadOnlyCollection<ProjectUser> projectUsersToAdd = users.Where(u => !projectUsers.Any(pu => pu.UserId == u.Id))
                .Select(u => new ProjectUser { UserId = u.Id, ProjectId = request.ProjectId })
                .ToList();

            await _context.ProjectUsers.AddRangeAsync(projectUsersToAdd, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            if (projectUsersToAdd.Count != users.Count)
            {
                throw new InvalidOperationException("Some users were not added because they could not be found" +
                    " or they are already members of this project");
            }

            return Unit.Value;
        }
    }
}
