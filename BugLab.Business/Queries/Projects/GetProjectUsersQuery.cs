using BugLab.Shared.Responses;
using MediatR;
using System.Collections.Generic;

namespace BugLab.Business.Queries.Projects
{
    public class GetProjectUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
        public GetProjectUsersQuery(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; }
    }
}
