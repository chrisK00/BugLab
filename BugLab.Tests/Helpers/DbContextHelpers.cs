using BugLab.Data;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestSupport.EfHelpers;

namespace BugLab.Tests.Helpers
{
    public static class DbContextHelpers
    {
        public static string CurrentUserId { get; private set; }

        public static async Task<AppDbContext> CreateAsync(string currentUserId = "757b2158-40c3-4917-9523-5861973a4d2e")
        {
            CurrentUserId = currentUserId;
            var options = SqliteInMemory.CreateOptions<AppDbContext>();

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, currentUserId) }));
            var mockHttpAccessor = new Mock<IHttpContextAccessor>();
            mockHttpAccessor.Setup(_ => _.HttpContext.User).Returns(claimsPrincipal);

            var context = new AppDbContext(options, mockHttpAccessor.Object);
            context.Database.EnsureCreated();
            context.SeedBugs();

            await context.SaveChangesAsync();

            context.ChangeTracker.Clear();
            return context;
        }
    }
}
