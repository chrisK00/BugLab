using BugLab.Business.Helpers;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Bugs
{
    public class GetBugsQuery : BugParams, IRequest<PagedList<BugResponse>>
    {
        public GetBugsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
