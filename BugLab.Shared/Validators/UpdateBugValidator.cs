using BugLab.Shared.Requests.Bugs;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class UpdateBugValidator : AbstractValidator<UpdateBugRequest>
    {
        public UpdateBugValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .IsInEnum();

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.TypeId)
                .NotEmpty();
        }
    }
}
