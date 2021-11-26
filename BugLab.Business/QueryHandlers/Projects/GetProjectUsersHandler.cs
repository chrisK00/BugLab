using BugLab.Business.Queries.Projects;
using BugLab.Data;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.QueryHandlers.Projects
{
    public class GetProjectUsersHandler : IRequestHandler<GetProjectUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly AppDbContext _context;

        public GetProjectUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetProjectUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProjectUsers.Include(pu => pu.User).AsNoTracking()
                .Where(pu => pu.ProjectId == request.ProjectId)
                .Select(pu => new UserResponse { Email = pu.User.Email, Id = pu.User.Id })
                .ToListAsync(cancellationToken);
        }
    }
}
