using System.Collections.Generic;

namespace BugLab.Shared.Responses
{
    public class UserResponse
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public IEnumerable<string> Roles { get; init; } = new List<string>();
        public string Token { get; set; }
    }
}
