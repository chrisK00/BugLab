using MediatR;

namespace BugLab.Business.Commands.Auth
{
    public class RegisterCommand : IRequest
    {
        public RegisterCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get;}
    }
}
