using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Shared.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.Queries.Users
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
                query = query.Where(x => x.Email.Contains(request.Email));

            if (request.NotInProjectId.HasValue)
            {
                query = query.Where(u => !_context.ProjectUsers.Any(pu => pu.ProjectId == request.NotInProjectId && pu.UserId == u.Id));
            }

            return await PagedList<UserResponse>.CreateAsync(query.ProjectToType<UserResponse>(),
                request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
