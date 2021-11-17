using BugLab.Business.Queries.Bugs;
using BugLab.Data.Entities;
using BugLab.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.QueryHandlers
{
    public class GetBugsHandlerTests
    {
        private GetBugsHandler _sut;

        [Fact]
        public async Task GetBugs_ShouldNot_ReturnDeletedBugs()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);

            var deletedBug = context.Bugs.IgnoreQueryFilters().FirstOrDefault(x => x.Deleted != null);
            var bugs = await _sut.Handle(new GetBugsQuery(DbContextHelpers.CurrentUserId), default);

            bugs.Should().NotBeNullOrEmpty();
            bugs.Should().NotContain(x => x.Title == deletedBug.Title);
        }
    }
}
