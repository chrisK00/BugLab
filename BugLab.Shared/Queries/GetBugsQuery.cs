using BugLab.Shared.Responses;
using MediatR;
using System.Collections.Generic;

namespace BugLab.Shared.Queries
{
    public class GetBugsQuery : IRequest<IEnumerable<BugResponse>>
    {
        public int? ProjectId { get; set; }
    }
}
