﻿using BugLab.Business.Commands.Comments;
using BugLab.Business.Helpers;
using BugLab.Data;
using BugLab.Data.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Comments
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly AppDbContext _context;

        public AddCommentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == request.BugId, cancellationToken);
            Guard.NotFound(bug, nameof(bug), request.BugId);

            var comment = request.Adapt<Comment>();
            bug.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
