﻿using BugLab.Business.Interfaces;
using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
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
                .Select(x => new
                {
                    UserIds = x.Users.Select(u => u.Id),
                    ProjectId = x.Id
                }).AnyAsync(x => x.UserIds.Contains(userId));

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }
    }
}