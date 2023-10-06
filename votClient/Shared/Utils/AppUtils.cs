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
    }
}
