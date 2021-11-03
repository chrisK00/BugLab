using BugLab.Shared.Commands;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddBugValidator : AbstractValidator<AddBugCommand>
    {
        public AddBugValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .IsInEnum();

            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}
