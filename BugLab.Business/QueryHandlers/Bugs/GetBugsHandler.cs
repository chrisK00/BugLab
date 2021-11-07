using BugLab.Data;
using BugLab.Shared.Helpers;
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

            if (request.ProjectId.HasValue) query = query.Where(x => x.ProjectId == request.ProjectId);
            else return new PagedList<BugResponse>(new List<BugResponse>(), 0, 1, 0);

            return await PagedList<BugResponse>.CreateAsync(query.ProjectToType<BugResponse>(), request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
