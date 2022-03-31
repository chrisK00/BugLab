using Blazored.LocalStorage;
using BugLab.Blazor.Helpers;
using BugLab.Shared.Requests.Auth;
using BugLab.Shared.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace BugLab.Blazor.Interceptors
{
    public class RefreshTokenInterceptor : IDisposable
    {
        private IHttpClientInterceptor _interceptor;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _client;

        public RefreshTokenInterceptor(IHttpClientInterceptor Interceptor, ILocalStorageService localStorage, HttpClient client)
        {
            _interceptor = Interceptor;
            _localStorage = localStorage;
            _client = client;
            _interceptor.BeforeSendAsync += InterceptRequestAsync;
        }

        private async Task InterceptRequestAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            var requestPath = e.Request.RequestUri.AbsolutePath;
            if (requestPath.Contains(Endpoints.Auth) || requestPath.Contains("token")) return;

            var user = await _localStorage.GetItemAsync<LoginResponse>("user");
            var claims = TokenHelper.ParseClaims(user.Token);
            var expirationDate = claims.GetExpirationDate();
            if (expirationDate > DateTime.UtcNow.AddMinutes(10)) return;

            var request = new RefreshTokenRequest { AccessToken = user.Token, RefreshToken = user.RefreshToken };
            var result = await _client.PostAsJsonAsync(Endpoints.Token, request);
            result.EnsureSuccessStatusCode();

            user.Token = await result.Content.ReadAsStringAsync();
            await _localStorage.SetItemAsync("user", user);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);
        }

        public void Dispose()
        {
            _interceptor.BeforeSendAsync -= InterceptRequestAsync;
        }
    }
}
