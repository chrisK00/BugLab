using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Shared.Commands
{
    public class LoginCommand : IRequest<UserResponse>
    {
        private string _email;

        public string Email { get => _email; set => _email = value.Trim(); }
        public string Password { get; set; }
    }
}
