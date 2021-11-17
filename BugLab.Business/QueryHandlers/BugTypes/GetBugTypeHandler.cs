using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.Queries.BugTypes
{
    public class GetBugTypeHandler : IRequestHandler<GetBugTypeQuery, BugTypeResponse>
    {
        private readonly AppDbContext _context;

        public GetBugTypeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BugTypeResponse> Handle(GetBugTypeQuery request, CancellationToken cancellationToken)
        {
            return await _context.BugTypes.AsNoTracking().ProjectToType<BugTypeResponse>()
                .FirstOrDefaultAsync(bt => bt.Id == request.Id, cancellationToken);
        }
    }
}
