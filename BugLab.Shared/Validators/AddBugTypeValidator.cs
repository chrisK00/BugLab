using BugLab.Shared.Requests.BugTypes;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddBugTypeValidator : AbstractValidator<AddBugTypeRequest>
    {
        public AddBugTypeValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty();

            RuleFor(x => x.ProjectId)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
