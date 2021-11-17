using BugLab.Business.CommandHandlers.Comments;
using BugLab.Business.Commands.Comments;
using BugLab.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class AddCommentHandlerTests
    {
        private AddCommentHandler _sut;

        [Fact]
        public async Task AddComment_AddsCommentToBug()
        {
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            var command = new AddCommentCommand(1, "comment text");
            await _sut.Handle(command, default);

            var bug = context.Bugs.First(b => b.Id == command.BugId);
            bug.Comments.Should().Contain(c => c.Text == command.Text);
        }
    }
}
