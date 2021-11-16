using BugLab.Business.Helpers;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Users
{
    public class GetUsersQuery : UserParams, IRequest<PagedList<UserResponse>>
    {

    }
}
