using BugLab.Business.Helpers;
using BugLab.Data;
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
                : query.Where(b => b.CreatedById == request.UserId);

            if (!string.IsNullOrWhiteSpace(request.Title)) query = query.Where(b => b.Title.Contains(request.Title));

            query = request.OrderBy switch
            {
                "title" => query.OrderBy(b => b.Status).ThenBy(b => b.Title),
                _ => query.OrderBy(b => b.Status).ThenBy(b => b.Priority)
            };

            return await PagedList<BugResponse>.CreateAsync(query.ProjectToType<BugResponse>(),
                request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
