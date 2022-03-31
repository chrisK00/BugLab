using BugLab.Business.Interfaces;
using BugLab.Business.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BugLab.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public TokenService(IOptions<JwtOptions> options, UserManager<IdentityUser> userManager, IEmailService emailService)
        {
            _jwtOptions = options.Value;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<string> GetJwtTokenAsync(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var credentials = GetSigningCredentials();
            var token = CreateToken(credentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken CreateToken(SigningCredentials credentials, IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken(_jwtOptions.ValidIssuer, _jwtOptions.ValidAudience, claims,
               expires: DateTime.UtcNow.AddMinutes(20), signingCredentials: credentials);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.TokenKey));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        }

        public string GetRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public async Task SendEmailConfirmationAsync(IdentityUser user)
        {
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailService.SendEmailConfirmationAsync(confirmationToken, user.Id, user.Email);
        }

        public void ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.TokenKey)),
                ValidateLifetime = false,
                ValidIssuer = _jwtOptions.ValidIssuer,
                ValidAudience = _jwtOptions.ValidAudience,
            };

            SecurityToken securityToken;
            try
            {
                new JwtSecurityTokenHandler()
                    .ValidateToken(token, validationParameters, out securityToken);
            }
            catch (Exception)
            {
                throw new SecurityTokenException("Invalid token");
            }

            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header
                .Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
        }
    }
}
