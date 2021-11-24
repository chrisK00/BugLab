using MediatR;

namespace BugLab.Business.Commands.Auth
{
    public class ResendEmailConfirmationCommand : IRequest
    {
        public ResendEmailConfirmationCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
