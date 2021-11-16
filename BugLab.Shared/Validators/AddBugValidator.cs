using BugLab.Shared.Requests.Bugs;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddBugValidator : AbstractValidator<AddBugRequest>
    {
        public AddBugValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .IsInEnum();

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.ProjectId)
                .NotEmpty();

            RuleFor(x => x.BugTypeId)
                .NotEmpty();
        }
    }
}
