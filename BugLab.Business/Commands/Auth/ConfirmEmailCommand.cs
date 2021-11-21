using MediatR;

namespace BugLab.Business.Commands.Auth
{
    public class ConfirmEmailCommand : IRequest
    {
        public ConfirmEmailCommand(string userId, string confirmationToken)
        {
            UserId = userId;
            ConfirmationToken = confirmationToken;
        }

        public string UserId { get; }
        public string ConfirmationToken { get; }
    }
}
