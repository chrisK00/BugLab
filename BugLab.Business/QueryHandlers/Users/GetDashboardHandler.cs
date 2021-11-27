using BugLab.Business.Queries.Users;
using BugLab.Data;
using BugLab.Shared.Enums;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            dashboard.LatestBug = await _context.Bugs.AsNoTracking()
                .Where(b => projectIds.Contains(b.ProjectId))
                .OrderByDescending(b => b.Created)
                .ProjectToType<BugResponse>()
                .FirstOrDefaultAsync(cancellationToken);

            dashboard.LatestUpdatedBug = await _context.Bugs.AsNoTracking()
                .Where(b => projectIds.Contains(b.ProjectId))
                .OrderByDescending(b => b.Modified)
                .ProjectToType<BugResponse>()
                .FirstOrDefaultAsync(cancellationToken);

            _logger.LogInformation("Getting bugs counts");
            var bugsCounts = await _context.Bugs.AsNoTracking()
                  .Where(b => projectIds.Contains(b.ProjectId))
                  .GroupBy(x => 1, (key, bugs) => new
                  {
                      TotalOpenBugs = bugs.Count(b => b.Status == BugStatus.Open),
                      TotalInProgressBugs = bugs.Count(b => b.Status == BugStatus.InProgress),
                      TotalHighPrioritizedOpenBugs = bugs.Count(b => b.Priority == BugPriority.High),
                      TotalBugsAssignedToMe = bugs.Count(b => b.AssignedToId == request.UserId)
                  }).FirstOrDefaultAsync(cancellationToken);

            bugsCounts.Adapt(dashboard);

            return dashboard;
        }
    }
}
