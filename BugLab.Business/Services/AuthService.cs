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
            var userIsInProject = await _context.ProjectUsers.AnyAsync(pu => pu.ProjectId == projectId && pu.UserId == userId);

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }

        public async Task HasAccessToBug(string userId, int bugId)
        {
            var userIsInProject = await _context.ProjectUsers.AnyAsync(pu => pu.UserId == userId
                                                                             && pu.ProjectId == _context.Bugs.FirstOrDefault(b => b.Id == bugId).ProjectId);

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }
    }
}
