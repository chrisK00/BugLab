using MediatR;
using System.Collections.Generic;

namespace BugLab.Business.Commands.Projects
{
    public class AddProjectUsersCommand : IRequest
    {
        public AddProjectUsersCommand(int projectId, IEnumerable<string> userIds)
        {
            ProjectId = projectId;
            UserIds = userIds;
        }

        public int ProjectId { get;  }
        public IEnumerable<string> UserIds { get;  }
    }
}
