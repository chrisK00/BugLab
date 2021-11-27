using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using System;

namespace BugLab.Tests.Helpers
{
    public static class Seed
    {
        public static void SeedBugs(this AppDbContext context)
        {
            context.Bugs.AddRange(
                new Bug { Title = "bug1", Priority = BugPriority.High, Status = BugStatus.Open, ProjectId = 1, BugTypeId = 1 },
                new Bug { Title = "bug2", ProjectId = 1, BugTypeId = 1, Deleted = DateTime.UtcNow }
            );
        }
    }
}
