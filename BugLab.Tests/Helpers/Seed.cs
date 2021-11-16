using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugLab.Tests.Helpers
{
    public static class Seed
    {
        public static void SeedProjects(this AppDbContext context)
        {
            context.Projects.AddRange(new List<Project>
            {
                new Project { Title = "project1"},
                new Project { Title = "project2"},
                new Project { Title = "project3"},
            });
        }

        public static void SeedUsers(this AppDbContext context)
        {
            var users = new List<IdentityUser>
            {
                new IdentityUser {
                    Id = "1",
                    Email = "chris@gmail.com",
                    NormalizedEmail = "CHRIS@GMAIL.COM",
                    UserName = "chris2@gmail.com",
                    NormalizedUserName = "CHRIS2@GMAIL.COM"
                },
            }.AddPasswordHash();

            context.Users.AddRange(users);
        }

        public static void SeedBugs(this AppDbContext context)
        {
            context.Bugs.AddRange(new List<Bug>
            {
                new Bug { Title = "bug1", Priority = BugPriority.High, Status = BugStatus.Open, ProjectId = 1, BugTypeId = 1 },
                new Bug { Title = "bug2", ProjectId = 1, BugTypeId = 1 },
                new Bug { Title = "bug3", ProjectId = 2, BugTypeId = 2 },
            });
        }

        public static void SeedBugTypes(this AppDbContext context)
        {
            context.BugTypes.AddRange(new List<BugType>
            {
                new BugType {  ProjectId = 1, Title = "issue"},
                new BugType {  ProjectId = 2, Title = "issue"},
                new BugType {  ProjectId = 3, Title = "issue"},
            });
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
