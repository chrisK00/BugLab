using BugLab.Shared.Commands;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddCommentValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentValidator()
        {
            RuleFor(x => x.BugId)
                .NotEmpty();

            RuleFor(x => x.Text)
                .NotEmpty();
        }
    }
}
