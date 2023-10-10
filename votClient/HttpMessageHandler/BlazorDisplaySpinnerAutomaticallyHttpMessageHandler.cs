using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using votClient.Shared.Services;

namespace votClient.HttpMessageHandler
{
    public class BlazorDisplaySpinnerAutomaticallyHttpMessageHandler : DelegatingHandler
    {
        private readonly SpinnerService _spinnerService;
        private readonly ISessionStorageService _sessionStorage;
        private readonly TokenServerAuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;
        public BlazorDisplaySpinnerAutomaticallyHttpMessageHandler(SpinnerService spinnerService, 
                                                            ISessionStorageService sessionStorage, 
                                                            TokenServerAuthenticationStateProvider authStateProvider, 
                                                            NavigationManager navigationManager)
        {
            _spinnerService = spinnerService;
            _sessionStorage= sessionStorage;
            _authStateProvider= authStateProvider;
            _navigationManager= navigationManager;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerService.Show();
            string jwtToken = await _sessionStorage.GetItemAsync<string>("jwt");
           
            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                request.Headers.Add("Authorization", $"Bearer {jwtToken}");
            }
             // Add whatever headers you want here
           

            var response = await base.SendAsync(request, cancellationToken);
            _spinnerService.Hide();

            if (!response.IsSuccessStatusCode) {
                await _authStateProvider.Logout();
                _navigationManager.NavigateTo("/login");
            }
           

            return response;
        }
    }
}
