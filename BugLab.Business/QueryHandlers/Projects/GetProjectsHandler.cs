using BugLab.Data;
using BugLab.Shared.Enums;
using BugLab.Shared.Helpers;
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
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, PagedList<ProjectResponse>>
    {
        private readonly AppDbContext _context;

        public GetProjectsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<ProjectResponse>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await PagedList<ProjectResponse>
                .CreateAsync(_context.Projects.ProjectToType<ProjectResponse>(), request.PageNumber, request.PageSize, cancellationToken);

            foreach (var project in projects)
            {
                var bugsCount = await _context.Bugs.AsNoTracking()
                  .Where(x => x.ProjectId == project.Id)
                  .GroupBy(bug => 1, (key, bugs) => new
                  {
                      Total = bugs.Count(),
                      HighPrioritized = bugs.Count(x => x.Priority == BugPriority.High)
                  }).FirstOrDefaultAsync(cancellationToken);

                project.TotalBugs = bugsCount.Total;
                project.TotalHighPriorityBugs = bugsCount.HighPrioritized;
            }

            return projects;
        }
    }
}