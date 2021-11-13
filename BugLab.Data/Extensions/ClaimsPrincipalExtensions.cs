using System.Security.Claims;

namespace BugLab.Data.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string UserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
