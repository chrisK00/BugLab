using BugLab.Shared.Requests.Comments;
using FluentValidation;

namespace BugLab.Shared.Validators
{
    public class UpsertCommentValidator : AbstractValidator<UpsertCommentRequest>
    {
        public UpsertCommentValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty();
        }
    }
}
