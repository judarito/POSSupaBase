using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net;
using votClient.Shared.Services;
using votClient.Shared.Utils;

namespace votClient.HttpMessageHandler
{
    public class BlazorDisplaySpinnerAutomaticallyHttpMessageHandler : DelegatingHandler
    {
        private readonly SpinnerService _spinnerService;
        private readonly ISessionStorageService _sessionStorage;
        private readonly TokenServerAuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public BlazorDisplaySpinnerAutomaticallyHttpMessageHandler(SpinnerService spinnerService,
                                                            ISessionStorageService sessionStorage,
                                                            TokenServerAuthenticationStateProvider authStateProvider,
                                                            NavigationManager navigationManager,
                                                            NotificationService notificationService)
        {
            _spinnerService = spinnerService;
            _sessionStorage = sessionStorage;
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            _spinnerService.Show();
            try
            {
                string jwtToken = await _sessionStorage.GetItemAsync<string>("jwt");

                if (!string.IsNullOrWhiteSpace(jwtToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {jwtToken}");
                }
                // Add whatever headers you want here


                response = await base.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await _authStateProvider.Logout();
                    _navigationManager.NavigateTo("/login");
                }

            }
            catch (Exception ex)
            {
                AppUtils.ShowNotify("Error de comunicación con la API", "ERROR", _notificationService);
            }
            finally
            {
                _spinnerService.Hide();
            }

            return response;
        }
    }
}
