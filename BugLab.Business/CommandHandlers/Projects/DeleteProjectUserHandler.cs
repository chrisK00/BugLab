using BugLab.Business.Commands.Projects;
using BugLab.Business.Helpers;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Projects
{
    public class DeleteProjectUserHandler : IRequestHandler<DeleteProjectUserCommand>
    {
        private readonly AppDbContext _context;

        public DeleteProjectUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectUserCommand request, CancellationToken cancellationToken)
        {
            // TODO: implement- ProjectUser table

            return Unit.Value;
        }
    }
}
