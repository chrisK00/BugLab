using BugLab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.BackgroundServices
{
    public class RemoveDeletedBugsService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<RemoveDeletedBugsService> _logger;

        public RemoveDeletedBugsService(IServiceScopeFactory serviceScopeFactory, ILogger<RemoveDeletedBugsService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogWarning("Removing deleted bugs");
                using var scope = _serviceScopeFactory.CreateScope();

                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var deletedBugs = await context.Bugs.IgnoreQueryFilters()
                        .Where(x => x.Deleted.HasValue && x.Deleted.Value < DateTime.UtcNow.AddDays(-30))
                        .ToListAsync(stoppingToken);

                    context.Bugs.RemoveRange(deletedBugs);
                    await context.SaveChangesAsync(stoppingToken);

                    _logger.LogInformation("Finished removing {Count} deleted bugs", deletedBugs.Count);
                    await Task.Delay(TimeSpan.FromDays(14), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}
