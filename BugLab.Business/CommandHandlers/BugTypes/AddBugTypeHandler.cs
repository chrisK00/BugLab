using BugLab.Business.Commands.BugTypes;
using BugLab.Data;
using BugLab.Data.Entities;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.BugTypes
{
    public class AddBugTypeHandler : IRequestHandler<AddBugTypeCommand, int>
    {
        private readonly AppDbContext _context;

        public AddBugTypeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddBugTypeCommand request, CancellationToken cancellationToken)
        {
            var newBugType = request.Adapt<BugType>();
            await _context.BugTypes.AddAsync(newBugType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newBugType.Id;
        }
    }
}
