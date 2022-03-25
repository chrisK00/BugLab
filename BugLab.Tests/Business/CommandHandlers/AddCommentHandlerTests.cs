using BugLab.Business.CommandHandlers.Comments;
using BugLab.Business.Commands.Comments;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class AddCommentHandlerTests
    {
        private AddCommentHandler _sut;
        private AddCommentCommand _command;

        [Fact]
        public async Task AddsCommentToBug()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new(1, Guid.NewGuid().ToString());
            
            await _sut.Handle(_command, default);

            var bug = context.Bugs.First(b => b.Id == _command.BugId);
            bug.Comments.Should().Contain(c => c.Text == _command.Text);
        }

        [Fact]
        public async Task ThrowsNotFound_If_BugDoesNotExist()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new AddCommentCommand(int.MaxValue, Guid.NewGuid().ToString());
            
            await _sut.Invoking(_ => _.Handle(_command, default))
                .Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
