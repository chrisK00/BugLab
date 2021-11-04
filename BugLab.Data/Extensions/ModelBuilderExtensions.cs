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
                    new Project { Id = 2, Title = "Plannial"}
                });

            builder.Entity<Bug>()
               .HasData(new List<Bug>
               {
                    new Bug { Id = 1, Title = "Implement project controllers", ProjectId = 1},
                    new Bug { Id = 2, Title = "update bugs controllers", ProjectId = 1},
               });
        }
    }
}
