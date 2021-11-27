using BugLab.Business.Extensions;
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

            _logger.LogInformation("Getting latest bugs for dashboard");
            var latestBugs = (await _context.Bugs.AsNoTracking()
                .GetBugsForUser(_context.ProjectUsers, request.UserId)
                .ProjectToType<BugResponse>().ToListAsync(cancellationToken))
                .GroupBy(x => 1, (key, bugs) => new
                {
                    latestBug = bugs.OrderByDescending(b => b.Created).FirstOrDefault(),
                    latestUpdatedBug = bugs.OrderByDescending(b => b.Modified).FirstOrDefault()
                }).FirstOrDefault();

            _logger.LogInformation("Getting latest comment");
            var latestComment = await _context.Bugs.AsNoTracking()
                .Include(b => b.Comments).ThenInclude(c => c.CreatedBy)
                .Include(b => b.Comments).ThenInclude(c => c.ModifiedBy)
                .OrderByDescending(b => b.Modified)
                .GetBugsForUser(_context.ProjectUsers, request.UserId)
                .Select(b => b.Comments.OrderByDescending(c => c.Created).FirstOrDefault().Adapt<CommentResponse>())
                .FirstOrDefaultAsync(cancellationToken);

            _logger.LogInformation("Getting bugs counts");
            var bugsCounts = await _context.Bugs.AsNoTracking()
                  .GetBugsForUser(_context.ProjectUsers, request.UserId)
                  .GroupBy(x => 1, (key, bugs) => new
                  {
                      TotalOpenBugs = bugs.Count(b => b.Status == BugStatus.Open),
                      TotalInProgressBugs = bugs.Count(b => b.Status == BugStatus.InProgress),
                      TotalHighPrioritizedOpenBugs = bugs.Count(b => b.Priority == BugPriority.High),
                      TotalAssignedBugs = bugs.Count(b => b.AssignedToId == request.UserId)
                  }).FirstOrDefaultAsync(cancellationToken);

            bugsCounts.Adapt(dashboard);
            dashboard.LatestComment = latestComment;
            dashboard.LatestUpdatedBug = latestBugs.latestUpdatedBug;
            dashboard.LatestBug = latestBugs.latestBug;

            return dashboard;
        }
    }
}
