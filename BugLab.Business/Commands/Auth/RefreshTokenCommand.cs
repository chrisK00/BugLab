using MediatR;

namespace BugLab.Business.Commands.Auth
{
    public class RefreshTokenCommand : IRequest<string>
    {
        public RefreshTokenCommand(string refreshToken, string accessToken)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }

        public string RefreshToken { get; }
        public string AccessToken { get; }
    }
}
