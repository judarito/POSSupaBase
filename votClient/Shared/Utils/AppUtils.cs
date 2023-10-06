using Radzen;

namespace votClient.Shared.Utils
{
    public static class AppUtils
    {
        public async static Task<bool> ShowConfirm(string Title, string Message, DialogService dialogService) => (bool)await dialogService.Confirm(Message, Title, new ConfirmOptions() { OkButtonText = "Si", CancelButtonText = "No" });
        public  static void ShowAlert(string Title, string Message, DialogService dialogService) =>  dialogService.Alert(Message, Title, new AlertOptions() { OkButtonText = "Ok" });
    }
}
