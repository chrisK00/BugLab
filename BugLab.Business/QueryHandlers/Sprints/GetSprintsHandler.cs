using BugLab.Business.Queries.Sprints;
using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Sprints
{
    public class GetSprintsHandler : IRequestHandler<GetSprintsQuery, IEnumerable<SprintResponse>>
    {
        private readonly AppDbContext _context;

        public GetSprintsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SprintResponse>> Handle(GetSprintsQuery request, CancellationToken cancellationToken)
        {
            var sprints = await _context.Sprints.AsNoTracking()
                .Where(s => s.ProjectId == request.ProjectId)
                .ProjectToType<SprintResponse>()
                .ToListAsync(cancellationToken);

            return sprints;
        }
    }
}
