using BugLab.Business.Interfaces;
using BugLab.Business.Options;
using BugLab.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public string CreateJwtToken(LoginResponse user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };

            claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.TokenKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenOptions = new JwtSecurityToken(_jwtOptions.ValidIssuer, _jwtOptions.ValidAudience, claims,
                expires: DateTime.Now.AddHours(12), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task SendEmailConfirmationAsync(IdentityUser user)
        {
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailService.SendEmailConfirmationAsync(confirmationToken, user.Id, user.Email);
        }
    }
}
