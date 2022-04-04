using BugLab.Business.Queries.Sprints;
using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Sprints
{
    public class GetSprintHandler : IRequestHandler<GetSprintQuery, SprintDetailsResponse>
    {
        private readonly AppDbContext _context;

        public GetSprintHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SprintDetailsResponse> Handle(GetSprintQuery request, CancellationToken cancellationToken)
        {
            var sprints = await _context.Sprints.AsNoTracking()
                .ProjectToType<SprintDetailsResponse>()
                .FirstOrDefaultAsync(s => s.Id == request.Id);

            return sprints;
        }
    }
}
