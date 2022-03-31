using Microsoft.AspNetCore.Identity;
using System;

namespace BugLab.Data.Entities
{
    public class RefreshToken
    {
        public string Value { get; init; }
        public DateTime ExpirationDate { get; init; }
        public IdentityUser User { get; init; }
        public string UserId { get; set; }
    }
}
