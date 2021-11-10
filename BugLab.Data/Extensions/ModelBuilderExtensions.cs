using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BugLab.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasData(
                    new Project { Id = 1, Title = "BugLab" },
                    new Project { Id = 2, Title = "Plannial" },
                    new Project { Id = 3, Title = "SweatSpace" }
                );

            builder.Entity<Bug>()
               .HasData(
                   new Bug { Id = 1, Title = "Implement project controllers", ProjectId = 1 },
                    new Bug { Id = 2, Title = "update project title", Description = "Better domaine events pattern", ProjectId = 1 },
                    new Bug { Id = 3, Title = "How you doing?", ProjectId = 2 }
                    );

            builder.Entity<Comment>().HasData(
                new { Id = 1, Text = "This has been implemented", Created = DateTime.UtcNow, BugId = 1 },
                new { Id = 2, Text = "Nope", Created = DateTime.UtcNow, BugId = 1 },
                new { Id = 3, Text = "Any progress?", Created = DateTime.UtcNow, BugId = 2 }
                );
        }
    }
}