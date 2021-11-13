using BugLab.Shared.Helpers;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Shared.Queries
{
    public class GetProjectsQuery : PaginationParams, IRequest<PagedList<ProjectResponse>>
    {
        
    }
}
