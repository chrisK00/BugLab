using BugLab.Business.Extensions;
using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Shared.Enums;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.Queries.Bugs
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
                ? query.Where(b => b.ProjectId == request.ProjectId)
                : query.Where(b => b.CreatedById == request.UserId || b.AssignedToId == request.UserId);

            if (!string.IsNullOrWhiteSpace(request.Title)) query = query.Where(b => b.Title.Contains(request.Title));

            var defaultOrder = query.OrderBy(b => b.Status);

            query = request.SortBy switch
            {
                BugSortBy.Title => defaultOrder.ThenSortBy(b => b.Title, request.SortOrder),
                _ => defaultOrder.ThenSortBy(b => b.Priority, request.SortOrder)
            };

            return await PagedList<BugResponse>.CreateAsync(query.ProjectToType<BugResponse>(),
                request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
