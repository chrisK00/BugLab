using BugLab.Shared.Requests.Projects;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddProjectValidator : AbstractValidator<AddProjectRequest>
    {
        public AddProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
