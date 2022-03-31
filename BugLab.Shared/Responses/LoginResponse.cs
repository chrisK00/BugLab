using System;
using System.Collections.Generic;

namespace BugLab.Shared.Responses
{
    public class LoginResponse
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; init; }
        public string RefreshToken { get; set; }
    }
}
