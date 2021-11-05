using BugLab.Shared.Commands;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommand>
    {
        public AddProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
