using BugLab.Data;
using BugLab.Data.Helpers;
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

        public static async Task<AppDbContext> CreateAsync(string currentUserId = "757b2158-40c3-4917-9523-5861973a4d2e", IDateProvider dateProvider = null)
        {
            CurrentUserId = currentUserId;
            var options = SqliteInMemory.CreateOptions<AppDbContext>();

            if (dateProvider == null) dateProvider = new DateProvider();

            var httpAccessor = CreateHttpAccessor();
            var context = new AppDbContext(options, dateProvider, httpAccessor);
            context.Database.EnsureCreated();
            context.SeedBugs();

            await context.SaveChangesAsync();

            context.ChangeTracker.Clear();
            return context;
        }

        private static IHttpContextAccessor CreateHttpAccessor()
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, CurrentUserId) }));
            var mockHttpAccessor = new Mock<IHttpContextAccessor>();
            mockHttpAccessor.Setup(_ => _.HttpContext.User).Returns(claimsPrincipal);

            return mockHttpAccessor.Object;
        }
    }
}
