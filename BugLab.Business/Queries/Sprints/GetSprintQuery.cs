using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.Sprints
{
    public class GetSprintQuery : IRequest<SprintDetailsResponse>
    {
        public GetSprintQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
