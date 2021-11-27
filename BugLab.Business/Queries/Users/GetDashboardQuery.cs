using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Users
{
    public class GetDashboardQuery : IRequest<DashboardResponse>
    {
        public GetDashboardQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
