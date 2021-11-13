using MediatR;
using System.Collections.Generic;

namespace BugLab.Shared.Commands
{
    public class AddProjectUsersCommand : IRequest
    {
        public IEnumerable<string> UserIds { get; set; }
        public int ProjectId { get; set; }
    }
}
