using BugLab.Business.Extensions;
using BugLab.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Cosmos.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.Extensions
{
    public class IQueryableExtensionsTests
    {
        [Fact]
        public async Task PaginateAsync_Returns_AmountOfTotalItems()
        {
            var context = await DbContextHelpers.CreateAsync();
            var expectedBugCount = await context.Bugs.CountAsync();

            var (query, bugCount) = await context.Bugs.PaginateAsync(1, 1, default);

            bugCount.Should().Be(expectedBugCount);
        }
    }
}
