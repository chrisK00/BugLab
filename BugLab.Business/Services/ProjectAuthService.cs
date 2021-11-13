using BugLab.Business.Interfaces;
using BugLab.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BugLab.Business.Services
{
    public class ProjectAuthService : IProjectAuthService
    {
        private readonly AppDbContext _context;

        public ProjectAuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task HasAccess(string userId, int projectId)
        {
            var userIsInProject = await _context.Projects.Where(x => x.Id == projectId)
                .AnyAsync(x => x.Users.Any(x => x.Id == userId));

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }
    }
}
