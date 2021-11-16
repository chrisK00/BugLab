using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Business.Commands.Auth
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
