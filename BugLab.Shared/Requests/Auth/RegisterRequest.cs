namespace BugLab.Shared.Requests.Auth
{
    public class RegisterRequest
    {
        private string _email;

        public string Email { get => _email; set => _email = value.Trim(); }
        public string Password { get; set; }
    }
}
