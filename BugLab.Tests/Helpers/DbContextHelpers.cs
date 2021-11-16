using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TestSupport.EfHelpers;

namespace BugLab.Tests.Helpers
{
    public static class DbContextHelpers
    {
        public static string CurrentUserId { get; private set; }

        public static async Task<AppDbContext> CreateAsync(string currentUserId = "1")
        {
            CurrentUserId = currentUserId;
            var options = SqliteInMemory.CreateOptions<AppDbContext>();
            await InitSeed(options);

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, currentUserId) }));
            var mockHttpAccessor = new Mock<IHttpContextAccessor>();
            mockHttpAccessor.Setup(_ => _.HttpContext.User).Returns(claimsPrincipal);

            var context = new AppDbContext(options, mockHttpAccessor.Object);
            context.SeedProjects();
            context.SeedBugTypes();
            context.SeedBugs();

            await context.SaveChangesAsync();

            return context;
        }

        private static async Task InitSeed(DbContextOptionsDisposable<AppDbContext> options)
        {
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            context.SeedUsers();

            await context.SaveChangesAsync();
        }
    }
}
