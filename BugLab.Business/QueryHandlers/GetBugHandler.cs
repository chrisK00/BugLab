using BugLab.Data;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers
{
    public class GetBugHandler : IRequestHandler<GetBugQuery, BugResponse>
    {
        private readonly AppDbContext _context;

        public GetBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BugResponse> Handle(GetBugQuery request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return bug.Adapt<BugResponse>();
        }
    }
}
