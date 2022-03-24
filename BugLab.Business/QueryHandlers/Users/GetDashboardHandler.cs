using BugLab.Business.Queries.Users;
using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BugLab.Business.QueryHandlers.Users
{
    public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, DashboardResponse>
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetDashboardHandler> _logger;

        public GetDashboardHandler(AppDbContext context, ILogger<GetDashboardHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DashboardResponse> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var dashboard = new DashboardResponse();

            _logger.LogInformation("Getting project ids for dashboard");
            var projectIds = await _context.ProjectUsers.Where(pu => pu.UserId == request.UserId)
                                                        .Select(pu => pu.ProjectId).ToListAsync(cancellationToken);

            _logger.LogInformation("Getting latest bugs");
            dashboard.LatestBug = await GetLatestBug(b => b.Created, projectIds, cancellationToken);
            dashboard.LatestUpdatedBug = await GetLatestBug(b => b.Modified, projectIds, cancellationToken);

            _logger.LogInformation("Getting bugs counts");
            var bugsCounts = await _context.Bugs.AsNoTracking()
                  .Where(b => projectIds.Contains(b.ProjectId))
                  .GroupBy(_ => 1, (_, bugs) => new
                  {
                      TotalOpenBugs = bugs.Count(b => b.Status == BugStatus.Open),
                      TotalInProgressBugs = bugs.Count(b => b.Status == BugStatus.InProgress),
                      TotalHighPrioritizedOpenBugs = bugs.Count(b => b.Priority == BugPriority.High),
                      TotalBugsAssignedToMe = bugs.Count(b => b.AssignedToId == request.UserId)
                  }).FirstOrDefaultAsync(cancellationToken);

            bugsCounts.Adapt(dashboard);

            return dashboard;
        }

        private async Task<BugResponse> GetLatestBug<TKey>(Expression<Func<Bug, TKey>> latestSelector, IEnumerable<int> projectIds
            , CancellationToken cancellationToken)
        {
            return await _context.Bugs.AsNoTracking()
               .Where(b => projectIds.Contains(b.ProjectId))
               .OrderByDescending(latestSelector)
               .ProjectToType<BugResponse>()
               .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
