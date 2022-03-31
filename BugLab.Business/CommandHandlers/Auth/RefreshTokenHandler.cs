using BugLab.Business.Commands.Auth;
using BugLab.Business.Helpers;
using BugLab.Business.Interfaces;
using BugLab.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public RefreshTokenHandler(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _context.RefreshTokens.Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Value == request.RefreshToken, cancellationToken);

            Guard.NotFound(refreshToken, "refresh token");

            if (refreshToken.ExpirationDate <= DateTime.UtcNow) throw new SecurityTokenException("Token has expired");
            _tokenService.ValidateToken(request.AccessToken);

            return await _tokenService.GetJwtTokenAsync(refreshToken.User);
        }
    }
}
