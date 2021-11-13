using BugLab.Shared.Helpers;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Shared.Queries
{
    public class GetUsersQuery : PaginationParams, IRequest<PagedList<UserResponse>>
    {
        public string Email { get; set; }
        public int? NotInProjectId { get; set; }
    }
}
