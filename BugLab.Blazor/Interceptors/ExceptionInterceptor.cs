using BugLab.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace BugLab.Blazor.Interceptors
{
    public class ExceptionInterceptor : IDisposable
    {
        private readonly IHttpClientInterceptor _interceptor;
        private readonly ISnackbar _snackbar;
        private readonly NavigationManager _nav;

        public ExceptionInterceptor(IHttpClientInterceptor Interceptor, ISnackbar Snackbar, NavigationManager Nav)
        {
            _interceptor = Interceptor;
            _snackbar = Snackbar;
            _nav = Nav;

            _interceptor.AfterSendAsync += InterceptResponseAsync;
        }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            _interceptor.AfterSendAsync -= InterceptResponseAsync;
        }

        private async Task InterceptResponseAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response.IsSuccessStatusCode) return;

            var capturedContent = await e.GetCapturedContentAsync();
            var response = await capturedContent.ReadFromJsonAsync<ApiError>();

            switch (e.Response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    _nav.NavigateTo("/404");
                    break;

                case HttpStatusCode.Forbidden:
                case HttpStatusCode.BadRequest:
                    _snackbar.Add(response.Message, Severity.Error);
                    break;

                default:
                    _nav.NavigateTo("/server-error");
                    break;
            }

            e.Response.EnsureSuccessStatusCode();
        }
    }
}
