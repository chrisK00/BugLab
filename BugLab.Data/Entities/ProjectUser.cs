using Microsoft.AspNetCore.Identity;

namespace BugLab.Data.Entities
{
    public class ProjectUser
    {
        public int ProjectId { get; init; }
        public string UserId { get; init; }
        public IdentityUser User { get; init; }
    }
}
