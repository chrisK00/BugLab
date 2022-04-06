using BugLab.Business.CommandHandlers.Projects;
using BugLab.Business.Commands.Projects;
using BugLab.Data.Entities;
using BugLab.Shared.Enums;
using BugLab.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class DeleteProjectHandlerTests
    {
        private DeleteProjectHandler _sut;
        private DeleteProjectCommand _command;

        [Fact]
        public async Task Throws_WhenHasRelatedNonResolvedBugs()
        {
            using var context = await DbContextHelpers.CreateAsync();
            var projectId = (await context.Bugs.FirstAsync(x => x.Status != BugStatus.Resolved)).ProjectId;
            _sut = new DeleteProjectHandler(context);

            await _sut.Invoking(_ => _.Handle(new DeleteProjectCommand(projectId), default))
                .Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task RemovesRelatedBugs_ThatAreResolvedOrDeleted()
        {
            using var context = await DbContextHelpers.CreateAsync();
            var project = (await context.AddSeedData(new Project { Title = "new project" }))[0];

            await context.AddSeedData(
                new Bug { Title = "bug", BugTypeId = 1, Status = BugStatus.Resolved, ProjectId = project.Id, CreatedById = DbContextHelpers.CurrentUserId },
               new Bug { Title = "bug", BugTypeId = 1, Deleted = DateTime.UtcNow, CreatedById = DbContextHelpers.CurrentUserId, ProjectId = project.Id });

            _sut = new DeleteProjectHandler(context);
            await _sut.Handle(new DeleteProjectCommand(project.Id), default);

            context.Bugs.IgnoreQueryFilters().Where(x => x.ProjectId == project.Id).ToList()
                .Should().BeEmpty();
        }
    }
}
