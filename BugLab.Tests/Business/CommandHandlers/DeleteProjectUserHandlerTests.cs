using BugLab.Business.CommandHandlers.Projects;
using BugLab.Business.Commands.Projects;
using BugLab.Tests.Helpers;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BugLab.Tests.Business.CommandHandlers
{
    public class DeleteProjectUserHandlerTests
    {
        private DeleteProjectUserHandler _sut;
        private DeleteProjectUserCommand _command;

        [Fact]
        public async Task RemovesUser_FromListOfUsers()
        {
            int projectId = 1;
            using var context = await DbContextHelpers.CreateAsync();
            _sut = new(context);
            _command = new(projectId, DbContextHelpers.CurrentUserId);

            await _sut.Handle(_command, default);

            context.Projects.Where(x => x.Id == projectId).Select(x => x.Users)
                .Should().NotContain(p => p.Any(x => x.Id == DbContextHelpers.CurrentUserId));
        }
    }
}
