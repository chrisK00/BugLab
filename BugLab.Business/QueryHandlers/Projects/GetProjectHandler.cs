﻿using BugLab.Data;
using BugLab.Shared.Enums;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Projects
{
    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectResponse>
    {
        private readonly AppDbContext _context;

        public GetProjectHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectResponse> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.ProjectToType<ProjectResponse>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (project == null) return project;

            var bugsCount = await _context.Bugs.AsNoTracking()
                .Where(x => x.ProjectId == request.Id)
                .GroupBy(bug => 1, (key, bugs) => new
                {
                    Total = bugs.Count(),
                    HighPrioritized = bugs.Count(x => x.Priority == BugPriority.High)
                }).FirstOrDefaultAsync(cancellationToken);

            project.TotalBugs = bugsCount.Total;
            project.TotalHighPriorityBugs = bugsCount.HighPrioritized;
            return project;
        }
    }
}