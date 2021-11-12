using Blazored.LocalStorage;
using BugLab.Shared.Responses;
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
        private readonly string _userKey = "user";
        private readonly AuthenticationState _anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

        public async Task<string> GetUserEmail() => (await _localStorage.GetItemAsync<LoginResponse>(_userKey))?.Email;

        public AuthState(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _localStorage.GetItemAsync<LoginResponse>(_userKey);
            if (string.IsNullOrWhiteSpace(user?.Token))
            {
                return _anonymous;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(_userKey);
            var authState = Task.FromResult<AuthenticationState>(_anonymous);
            _client.DefaultRequestHeaders.Authorization = null;

            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LogInAsync(LoginResponse user)
        {
            var authUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(authUser));
            await _localStorage.SetItemAsync(_userKey, user);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

            NotifyAuthenticationStateChanged(authState);
        }
    }
}
