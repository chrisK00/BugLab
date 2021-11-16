using BugLab.Business.Helpers;
using BugLab.Shared.QueryParams;
using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Projects
{
    public class GetProjectsQuery : PaginationParams, IRequest<PagedList<ProjectResponse>>
    {

    }
}
