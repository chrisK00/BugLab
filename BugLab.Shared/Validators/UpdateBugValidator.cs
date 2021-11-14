using BugLab.Shared.Commands;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class UpdateBugValidator : AbstractValidator<UpdateBugCommand>
    {
        public UpdateBugValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .IsInEnum();

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.BugTypeId)
                .NotEmpty();
        }
    }
}
