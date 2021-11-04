using BugLab.Data;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Bugs
{
    public class GetBugHandler : IRequestHandler<GetBugQuery, BugResponse>
    {
        private readonly AppDbContext _context;

        public GetBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public Task<BugResponse> Handle(GetBugQuery request, CancellationToken cancellationToken)
        {
            return _context.Bugs.AsNoTracking()
                .ProjectToType<BugResponse>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
