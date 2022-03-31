using BugLab.Business.Queries.Bugs;
using BugLab.Data.Entities;
using BugLab.Shared.Responses;
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

        private bool AssignedToOrCreatedBy(BugResponse bug, string userId)
        {
            if (bug.CreatedBy.Id == userId) return true;

            var assignedToId = bug.AssignedTo?.Id;
            return assignedToId != null && assignedToId == userId;
        }

        [Fact]
        public async Task GetBugs_ShouldNot_ReturnDeletedBugs()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);

            var deletedBug = context.Bugs.IgnoreQueryFilters().FirstOrDefault(x => x.Deleted.HasValue);
            var bugs = await _sut.Handle(new GetBugsQuery(DbContextHelpers.CurrentUserId), default);

            bugs.Should().NotBeNullOrEmpty();
            bugs.Should().NotContain(x => x.Title == deletedBug.Title);
        }

        [Fact]
        public async Task GetBugs_WithUserId_ReturnsUsersBugs()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);

            var bugs = await _sut.Handle(new GetBugsQuery(DbContextHelpers.CurrentUserId), default);

            bugs.Should().NotBeNullOrEmpty();
            bugs.Should().Match(b => b.All(b => AssignedToOrCreatedBy(b, DbContextHelpers.CurrentUserId)));
        }

       [Fact]
        public async Task GetBugs_WithProjectId_ReturnsBugsInProject()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);

            var request = new GetBugsQuery(DbContextHelpers.CurrentUserId);
            request.ProjectId = context.ProjectUsers.AsNoTracking().First(x => x.UserId == DbContextHelpers.CurrentUserId).ProjectId;
            var bugs = await _sut.Handle(request, default);

            bugs.Should().NotBeNullOrEmpty();
            bugs.Should().Match(b => b.All(b => b.ProjectId == request.ProjectId));
        }
    }
}
