using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Queries.BugTypes
{
    public class GetBugTypeQuery : IRequest<BugTypeResponse>
    {
        public GetBugTypeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
