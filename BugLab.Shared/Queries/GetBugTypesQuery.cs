using BugLab.Shared.Responses;
using MediatR;
using System.Collections.Generic;

namespace BugLab.Shared.Queries
{
    public class GetBugTypesQuery : IRequest<IEnumerable<BugTypeResponse>>
    {
        public int ProjectId { get; private set; }

        public GetBugTypesQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
