using Microsoft.AspNetCore.Identity;
using System;

namespace BugLab.Data.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Value { get; init; }
        public DateTime ExpirationDate { get; init; } = DateTime.UtcNow.AddMonths(1);
        public IdentityUser User { get; init; }
        public string UserId { get; set; }
    }
}
