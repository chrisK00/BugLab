using BugLab.Business.QueryHandlers.Projects;
using BugLab.Shared.Queries;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.QueryHandlers
{
    public class GetProjectHandlerTests
    {
        private GetProjectHandler _sut;

        [Fact]
        public async Task GetProject_ReturnsNull_WhenNotFound()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            var result = await _sut.Handle(new GetProjectQuery(default), default);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetProject_ReturnsSpecifiedProject_With_BugsCount()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            var projectId = context.Projects.FirstOrDefault().Id;
            var result = await _sut.Handle(new GetProjectQuery(projectId), default);

            result.Should().NotBeNull();
            result.Id.Should().Be(projectId);
            result.TotalBugs.Should().BeGreaterThan(0);
            result.TotalHighPriorityBugs.Should().BeGreaterThan(0);
        }
    }
}
