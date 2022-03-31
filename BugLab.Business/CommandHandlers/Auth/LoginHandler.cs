using BugLab.Business.Commands.Auth;
using BugLab.Business.Interfaces;
using BugLab.Data;
using BugLab.Data.Entities;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.CommandHandlers.Auth
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginHandler(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            ITokenService tokenService, AppDbContext context)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            _ = user ?? throw new UnauthorizedAccessException("Failed to login");

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!loginResult.Succeeded) throw new UnauthorizedAccessException("Invalid username or password");

            var userResponse = new LoginResponse
            {
                Email = user.Email,
                Id = user.Id,
                EmailConfirmed = user.EmailConfirmed
            };

            userResponse.Token = await _tokenService.GetJwtTokenAsync(user);
            userResponse.RefreshToken = _tokenService.GetRefreshToken();

            await _context.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                Value = userResponse.RefreshToken
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return userResponse;
        }
    }
}
