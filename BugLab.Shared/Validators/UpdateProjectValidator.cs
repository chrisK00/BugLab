using BugLab.Shared.Requests.Projects;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class UpdateProjectValidator : AbstractValidator<UpdateProjectRequest>
    {
        public UpdateProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
