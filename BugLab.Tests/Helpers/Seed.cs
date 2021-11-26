using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BugLab.Tests.Helpers
{
    public static class Seed
    {
        public static void SeedProjects(this AppDbContext context)
        {
            var projects = new List<Project>
            {
                new Project { Title = "project1" },
                new Project { Title = "project2"},
                new Project { Title = "project3"},
            };

            context.Projects.AddRange(projects);
        }

        public static void SeedUsers(this AppDbContext context)
        {
            var users = new List<IdentityUser>
            {
                new IdentityUser {
                    Id = "1",
                    Email = "temp@gmail.com",
                    NormalizedEmail = "TEMP@GMAIL.COM",
                    UserName = "TEMPP@gmail.com",
                    NormalizedUserName = "TEMPP@GMAIL.COM"
                },new IdentityUser {
                    Id = "2",
                    Email = "tempp2@gmail.com",
                    NormalizedEmail = "TEMPP2@GMAIL.COM",
                    UserName = "tempp22@gmail.com",
                    NormalizedUserName = "TEMPP22@GMAIL.COM"
                }
            }.AddPasswordHash();

            context.Users.AddRange(users);
        }

        public static void SeedBugs(this AppDbContext context)
        {
            context.Bugs.AddRange(
                new Bug { Title = "bug1", Priority = BugPriority.High, Status = BugStatus.Open, ProjectId = 1, BugTypeId = 1 },
                new Bug { Title = "bug2", ProjectId = 1, BugTypeId = 1, Deleted = DateTime.UtcNow },
                new Bug { Title = "bug3", ProjectId = 1, BugTypeId = 1 },
                new Bug { Title = "bug4", ProjectId = 2, BugTypeId = 2 },
                new Bug { Title = "bug4", ProjectId = 3, BugTypeId = 1 }
            );
        }

        public static void SeedBugTypes(this AppDbContext context)
        {
            context.BugTypes.AddRange(
                new BugType {  ProjectId = 1, Title = "issue", Color ="#fff"},
                new BugType {  ProjectId = 2, Title = "issue", Color ="rgb(255, 255, 255)"},
                new BugType {  ProjectId = 3, Title = "issue", Color = "red"}
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
