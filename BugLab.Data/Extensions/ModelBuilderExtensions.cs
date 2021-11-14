using BugLab.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BugLab.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var userId = "757b2158-40c3-4917-9523-5861973a4d2e";
            var userId2 = "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62";

            var users = new List<IdentityUser>
            {
                new IdentityUser { Id = userId, Email = "chris@gmail.com", NormalizedEmail = "CHRIS@GMAIL.COM", UserName = "chris@gmail.com", NormalizedUserName = "CHRIS@GMAIL.COM"},
                new IdentityUser { Id = userId2, Email = "chrisk@gmail.com", UserName= "chrisk@gmail.com", NormalizedEmail="CHRISK@GMAIL.COM", NormalizedUserName ="CHRISK@GMAIL.COM" }
            }.AddPasswordHash();

            builder.Entity<IdentityUser>().HasData(users);

            builder.Entity<Project>().HasData(
                    new Project { Id = 1, Title = "BugLab" },
                    new Project { Id = 2, Title = "Plannial" },
                    new Project { Id = 3, Title = "SweatSpace" }
                );

            builder.Entity("IdentityUserProject").HasData(
                new { ProjectsId = 1, UsersId = userId },
                new { ProjectsId = 2, UsersId = userId },
                new { ProjectsId = 3, UsersId = userId2 }
                );

            builder.Entity<Bug>().HasData(
                   new Bug { Id = 1, Title = "Implement project controllers", ProjectId = 1, CreatedById = userId, BugTypeId = 3 },
                    new Bug { Id = 2, Title = "update project title", Description = "Better domaine events pattern", ProjectId = 1, CreatedById = userId, BugTypeId = 1 },
                    new Bug { Id = 3, Title = "How you doing?", ProjectId = 2, CreatedById = userId2, BugTypeId = 1 }
                    );

            builder.Entity<Comment>().HasData(
                new { Id = 1, Text = "This has been implemented", Created = DateTime.UtcNow, BugId = 1, CreatedById = userId },
                new { Id = 2, Text = "Nope", Created = DateTime.UtcNow, BugId = 1, CreatedById = userId },
                new { Id = 3, Text = "Any progress?", Created = DateTime.UtcNow, BugId = 2, CreatedById = userId2 }
                );

            builder.Entity<BugType>().HasData(
                new BugType { Id = 1, ProjectId = 1, Title = "refactor" },
                new BugType { Id = 2, ProjectId = 1, Title = "bug" },
                new BugType { Id = 3, ProjectId = 1, Title = "feature" },
                new BugType { Id = 4, ProjectId = 2, Title = "feature" },
                new BugType { Id = 5, ProjectId = 2, Title = "bug" },
                new BugType { Id = 6, ProjectId = 2, Title = "refactor" }
                );
        }

        private static List<IdentityUser> AddPasswordHash(this List<IdentityUser> users)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "Password123.");
            }

            return users;
        }
    }
}