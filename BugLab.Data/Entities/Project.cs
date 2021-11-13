using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BugLab.Data.Entities
{
    public class Project
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<IdentityUser> Users { get; set; } = new();
    }
}
