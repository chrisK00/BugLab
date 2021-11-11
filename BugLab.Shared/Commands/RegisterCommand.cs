using MediatR;

namespace BugLab.Shared.Commands
{
    public class RegisterCommand : IRequest
    {
        private string _email;

        public string Email { get => _email; set => _email = value.Trim(); }
        public string Password { get; set; }
    }
}
