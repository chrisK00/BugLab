using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BugLab.Business.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetJwtTokenAsync(IdentityUser user);
        string GetRefreshToken();
        Task SendEmailConfirmationAsync(IdentityUser user);
        void ValidateToken(string accessToken);
    }
}
