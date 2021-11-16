using BugLab.Shared.Responses;
using MediatR;
using System.Collections.Generic;

namespace BugLab.Business.Queries.BugTypes
{
    public class GetBugTypesQuery : IRequest<IEnumerable<BugTypeResponse>>
    {
        public GetBugTypesQuery(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; }
    }
}
