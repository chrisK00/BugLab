using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Projects
{
    public class GetProjectQuery : IRequest<ProjectResponse>
    {
        public GetProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
