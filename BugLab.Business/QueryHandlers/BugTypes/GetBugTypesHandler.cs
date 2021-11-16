using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.Queries.BugTypes
{
    public class GetBugTypesHandler : IRequestHandler<GetBugTypesQuery, IEnumerable<BugTypeResponse>>
    {
        private readonly AppDbContext _context;

        public GetBugTypesHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BugTypeResponse>> Handle(GetBugTypesQuery request, CancellationToken cancellationToken)
        {
            var bugTypes = await _context.BugTypes.AsNoTracking()
                .Where(x => x.ProjectId == request.ProjectId)
                .ProjectToType<BugTypeResponse>().ToListAsync(cancellationToken);

            return bugTypes;
        }
    }
}
