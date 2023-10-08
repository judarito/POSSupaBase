using Radzen;

namespace votClient.Shared.Utils
{
    public static class AppUtils
    {
        public async static Task<bool> ShowConfirm(string Title, string Message, DialogService dialogService)
        {
            var result = await dialogService.Confirm(Message, Title, new ConfirmOptions() { OkButtonText = "Si", CancelButtonText = "No" });
            return result != null ? (bool)result : false;
        }
        public static void ShowAlert(string Title, string Message, DialogService dialogService) => dialogService.Alert(Message, Title, new AlertOptions() { OkButtonText = "Ok" });

        public static void ShowNotify(string Message ,string Severity, NotificationService Ds) {
            switch (Severity)
            {
                case "ERROR":
                    Ds.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Message, Duration = 4000 });
                    break;
                case "OK":
                    Ds.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Exitóso", Detail = Message, Duration = 4000 });
                    break;
                case "WARNING":
                    Ds.Notify(new NotificationMessage { Severity = NotificationSeverity.Warning, Summary = "Precaución", Detail = Message, Duration = 4000 });
                    break;
                case "INFO":
                    Ds.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Información", Detail = Message, Duration = 4000 });
                    break;
                default:
                    Ds.Notify(new NotificationMessage { Severity = NotificationSeverity.Warning, Summary = "Precaución", Detail = Message, Duration = 4000 });
                    break;
            }

        }
    }
}
