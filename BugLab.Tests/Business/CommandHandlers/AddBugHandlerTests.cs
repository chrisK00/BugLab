using BugLab.Business.CommandHandlers.Bugs;
using BugLab.Business.Commands.Bugs;
using BugLab.Shared.Enums;
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
        public async Task SetsCreatedTime_ToCurrentTime()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            var command = new AddBugCommand("New Bug",null ,BugPriority.None, BugStatus.InProgress, 1, 1, null);
            var id = await _sut.Handle(command, default);

            id.Should().NotBe(0);
            var addedBug = context.Bugs.OrderBy(x => x.Id).LastOrDefault();
            addedBug.Created.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
        }
    }
}
