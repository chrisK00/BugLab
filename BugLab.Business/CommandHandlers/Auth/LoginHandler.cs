using BugLab.Business.Commands.Auth;
using BugLab.Business.Interfaces;
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
        private readonly UserManager<IdentityUser> _userManager;

        public LoginHandler(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            _ = user ?? throw new UnauthorizedAccessException("Failed to login");

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!loginResult.Succeeded) throw new UnauthorizedAccessException("Invalid username or password");

            var roles = await _userManager.GetRolesAsync(user);

            var userResponse = new LoginResponse
            {
                Roles = roles,
                Email = user.Email,
                Id = user.Id,
            };

            userResponse.Token = _tokenService.CreateToken(userResponse);
            return userResponse;
        }
    }
}
