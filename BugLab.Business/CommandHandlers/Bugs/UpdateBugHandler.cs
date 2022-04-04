﻿using BugLab.Business.Commands.Bugs;
using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Bugs
{
    public class UpdateBugHandler : IRequestHandler<UpdateBugCommand>
    {
        private readonly AppDbContext _context;

        public UpdateBugHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.Id);

            bug.Title = request.Title;
            bug.Status = request.Status;
            bug.Priority = request.Priority;
            bug.Description = request.Description;
            bug.BugTypeId = request.TypeId;
            bug.AssignedToId = request.AssignedToId;
            bug.SprintId = request.SprintId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
