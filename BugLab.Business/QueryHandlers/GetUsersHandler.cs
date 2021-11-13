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

namespace BugLab.Business.QueryHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, PagedList<UserResponse>>
    {
        private readonly AppDbContext _context;

        public GetUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return await PagedList<UserResponse>.CreateAsync(query.ProjectToType<UserResponse>(), request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
