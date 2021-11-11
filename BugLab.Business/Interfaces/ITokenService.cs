using BugLab.Shared.Responses;

namespace BugLab.Business.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserResponse user);
    }
}
