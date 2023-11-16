using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net;
using CommonBase.Shared.Services;
using CommonBase.Shared.Utils;
using CommonBase.Services.AuthService;

namespace votClient.HttpMessageHandler
{
    public class BlazorDisplaySpinnerAutomaticallyHttpMessageHandler : DelegatingHandler
    {
        private readonly SpinnerService _spinnerService;
        private readonly ISessionStorageService _sessionStorage;
        private readonly AuthService _authService;
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public BlazorDisplaySpinnerAutomaticallyHttpMessageHandler(SpinnerService spinnerService,
                                                            ISessionStorageService sessionStorage,
                                                            AuthService authService,
                                                            NavigationManager navigationManager,
                                                            NotificationService notificationService)
        {
            _spinnerService = spinnerService;
            _sessionStorage = sessionStorage;
            _authService = authService;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            _spinnerService.Show();
            try
            {
             
              

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
