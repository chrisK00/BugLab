using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BugLab.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasData(new List<Project>
                {
                    new Project { Id = 1, Title = "BugLab"},
                    new Project { Id = 2, Title = "Plannial"},
                    new Project { Id = 3, Title = "SweatSpace"}
                });

            builder.Entity<Bug>()
               .HasData(new List<Bug>
               {
                    new Bug { Id = 1, Title = "Implement project controllers", ProjectId = 1},
                    new Bug { Id = 2, Title = "update project title", Description = "Better domaine events pattern", ProjectId = 1},
                    new Bug { Id = 3, Title = "How you doing?", ProjectId = 2},
               });
        }
    }
}
