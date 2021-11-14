using BugLab.Business.Interfaces;
using BugLab.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BugLab.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task HasAccessToProject(string userId, int projectId)
        {
            var userIsInProject = await _context.Projects.Where(x => x.Id == projectId)
                .AnyAsync(x => x.Users.Any(x => x.Id == userId));

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }

        public async Task HasAccessToBug(string userId, int bugId)
        {
            var userIsInProject = await _context.Projects.Where(x => x.Id == _context.Bugs.AsNoTracking().FirstOrDefault(x => x.Id == bugId).ProjectId)
             .AnyAsync(x => x.Users.Any(x => x.Id == userId));

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }
    }
}
