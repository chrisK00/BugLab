using BugLab.Data;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Bugs
{
    public class GetBugsHandler : IRequestHandler<GetBugsQuery, IEnumerable<BugResponse>>
    {
        private readonly AppDbContext _context;

        public GetBugsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BugResponse>> Handle(GetBugsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Bugs.AsNoTracking();

            if (request.ProjectId.HasValue) query = query.Where(x => x.ProjectId == request.ProjectId);
            else return await Task.FromResult(new List<BugResponse>());

            return await query.ProjectToType<BugResponse>().ToListAsync(cancellationToken);
        }
    }
}
