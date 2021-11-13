using BugLab.Business.CommandHandlers.Bugs;
using BugLab.Shared.Commands;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class AddBugHandlerTests
    {
        private AddBugHandler _sut;

        [Fact]
        public async Task AddBug_SetsCreatedTime_ToCurrentTime()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            var request = new AddBugCommand { Title = "New Bug",ProjectId = 1 };
            var id = await _sut.Handle(request, default);

            id.Should().NotBe(0);
            var addedBug = context.Bugs.OrderBy(x => x.Id).LastOrDefault();
            addedBug.Created.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
        }
    }
}
