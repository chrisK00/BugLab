using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Shared.Queries
{
    public class GetProjectQuery : IRequest<ProjectResponse>
    {
        public GetProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
