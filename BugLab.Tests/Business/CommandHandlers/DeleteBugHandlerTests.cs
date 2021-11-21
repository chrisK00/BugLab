using BugLab.Business.CommandHandlers.Bugs;
using BugLab.Business.Commands.Bugs;
using BugLab.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class DeleteBugHandlerTests
    {
        private DeleteBugHandler _sut;
        private DeleteBugCommand _command = new(1);

        [Fact]
        public async Task SoftDeletes()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            await _sut.Handle(_command, default);

            var deletedBug = context.Bugs.IgnoreQueryFilters().First(x => x.Id == _command.Id);
            deletedBug.Should().NotBeNull();
            deletedBug.Deleted.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
        }
    }
}
