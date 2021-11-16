using BugLab.Shared.Requests.Comments;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class AddCommentValidator : AbstractValidator<AddCommentRequest>
    {
        public AddCommentValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();
        }
    }
}
