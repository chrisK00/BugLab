using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestSupport.EfHelpers;

namespace BugLab.Tests.Helpers
{
    public static class DbContextHelpers
    {
        public static async Task<AppDbContext> CreateAsync()
        {
            var options = SqliteInMemory.CreateOptions<AppDbContext>();
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            context.SeedProjects();
            context.SeedBugs();
            await context.SaveChangesAsync();

            return context;
        }

        public static void SeedProjects(this AppDbContext context)
        {
            context.Projects.AddRange(new List<Project>
            {
                new Project { Title = "project1"},
                new Project { Title = "project2"},
                new Project { Title = "project3"},
            });
        }

        public static void SeedBugs(this AppDbContext context)
        {
            context.Bugs.AddRange(new List<Bug>
            {
                new Bug { Title = "bug1", Priority = BugPriority.High, Status = BugStatus.Open, ProjectId = 1 },
                new Bug { Title = "bug2", ProjectId = 1 },
                new Bug { Title = "bug3", ProjectId = 2 },
            });
        }
    }
}
