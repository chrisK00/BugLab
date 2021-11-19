using BugLab.Shared.Requests.BugTypes;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class UpsertBugTypeValidator : AbstractValidator<UpsertBugTypeRequest>
    {
        public UpsertBugTypeValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
