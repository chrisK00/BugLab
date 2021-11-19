using BugLab.Business.Services;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.Services
{
    public class AuthServiceTests
    {
        private AuthService _sut;

        [Fact]
        public async Task HasAccessToProject_OnlyThrowsException_WhenUserIsNotInProject()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);

            await _sut.Invoking(_ => _.HasAccessToProject(Guid.NewGuid().ToString(), 1))
                .Should().ThrowAsync<UnauthorizedAccessException>();

            await _sut.Invoking(_ => _.HasAccessToProject(DbContextHelpers.CurrentUserId, 1))
              .Should().NotThrowAsync();
        }
    }
}
