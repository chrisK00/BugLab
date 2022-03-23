using Blazored.LocalStorage;
using BugLab.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugLab.Blazor.Helpers
{
    public class AuthState : AuthenticationStateProvider
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _nav;
        private readonly string _userKey = "user";
        private readonly AuthenticationState _anonymous = new(new ClaimsPrincipal());

        public AuthState(HttpClient client, ILocalStorageService localStorage, NavigationManager Nav)
        {
            _client = client;
            _localStorage = localStorage;
            _nav = Nav;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _localStorage.GetItemAsync<LoginResponse>(_userKey);
            if (string.IsNullOrWhiteSpace(user?.Token) || TokenHelper.ParseClaims(user.Token).HasExpired())
            {
                return _anonymous;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

            return CreateAuthenticationState(user);
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(_userKey);
            var authState = Task.FromResult(_anonymous);
            _client.DefaultRequestHeaders.Authorization = null;

            NotifyAuthenticationStateChanged(authState);
            _nav.NavigateTo("/home");
        }

        public async Task LogInAsync(LoginResponse user)
        {
            var state = CreateAuthenticationState(user);
            var authStateTask = Task.FromResult(state);
            await _localStorage.SetItemAsync(_userKey, user);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

            NotifyAuthenticationStateChanged(authStateTask);
        }

        private AuthenticationState CreateAuthenticationState(LoginResponse user)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            }, "Bearer")));
        }
    }
}
