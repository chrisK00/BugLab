using BugLab.Data;
using BugLab.Shared.Helpers;
using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Bugs
{
    public class GetBugsHandler : IRequestHandler<GetBugsQuery, PagedList<BugResponse>>
    {
        private readonly AppDbContext _context;

        public GetBugsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<BugResponse>> Handle(GetBugsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Bugs.AsNoTracking();

            query = request.ProjectId.HasValue
                ? query.Where(x => x.ProjectId == request.ProjectId)
                : query.Where(b => b.CreatedById == request.UserId);

            return await PagedList<BugResponse>.CreateAsync(query.ProjectToType<BugResponse>(), request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
