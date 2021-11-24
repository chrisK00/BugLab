using BugLab.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BugLab.Business.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtToken(LoginResponse user);
        Task SendEmailConfirmationAsync(IdentityUser user);
    }
}
