using DevAssessment.Views;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.Extensions
{
    public static class DialogExtension
    {
        public static void DisplayAlert(this IDialogService dialogService, string message)
        {
            var parameters = new DialogParameters();
            parameters.Add("Message", message);

            dialogService.ShowDialog(nameof(AlertDialogPage), parameters, CloseDialogCallback);
        }

        public static void DisplayError(this IDialogService dialogService, Exception ex, string message = null)
        {
            var parameters = new DialogParameters();

            if (string.IsNullOrEmpty(message))
            {
                parameters.Add("Message", ex.Message);
            }
            else
            {
                parameters.Add("Message", message);
            }

            parameters.Add("Exception", ex);

            dialogService.ShowDialog(nameof(ErrorDialogPage), parameters, CloseDialogCallback);
        }

        public static void DisplayNews(this IDialogService dialogService, string url)
        {
            var parameters = new DialogParameters
            {
                { "NewsReaderDialogUrl", url }
            };

            dialogService.ShowDialog(nameof(NewsReaderDialogPage), parameters, CloseDialogCallback);
        }

        private static void CloseDialogCallback(IDialogResult dialogResult) { }
    }
}
