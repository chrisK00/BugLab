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
            return await _context.Projects.AsNoTracking().Where(p => p.Id == request.ProjectId)
                .Select(p => p.Users.Select(u => new UserResponse { Email = u.Email, Id = u.Id }))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
