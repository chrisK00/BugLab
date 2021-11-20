using BugLab.Business.CommandHandlers.Projects;
using BugLab.Business.Commands.Projects;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class AddProjectUsersHandlerTests
    {
        private AddProjectUsersHandler _sut;
        private AddProjectUsersCommand _command;

        [Fact]
        public async Task ThrowsException_WhenTryingToAdd_AlreadyExistingUser()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new(1, new string[] { DbContextHelpers.CurrentUserId });

            await _sut.Invoking(_ => _.Handle(_command, default))
                   .Should().ThrowAsync<InvalidOperationException>();
        }
    }
}
