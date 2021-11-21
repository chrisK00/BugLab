using BugLab.Business.CommandHandlers.BugTypes;
using BugLab.Business.Commands.BugTypes;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class DeleteBugTypeHandlerTests
    {
        private DeleteBugTypeHandler _sut;
        private DeleteBugTypeCommand _command;

        [Fact]
        public async Task Throws_WhenBugType_IsNotFound()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new(int.MaxValue);

            await _sut.Invoking(_ => _.Handle(_command, default))
                .Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task Throws_WhenBugType_IsUsedByOtherBugs()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new(1);

            await _sut.Invoking(_ => _.Handle(_command, default))
                .Should().ThrowAsync<InvalidOperationException>();
        }
    }
}
