using BugLab.Shared.Requests.Sprints;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddSprintValidator : AbstractValidator<AddSprintRequest>
    {
        public AddSprintValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate).WithMessage("Sprint cannot end before start date");
        }
    }
}
