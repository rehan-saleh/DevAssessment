using Common.Localization;
using DevAssessment.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DevAssessment.ViewModels
{
    public class DialogDisplayPageViewModel : BindableBase
    {
        private IDialogService DialogService { get; }

        public DialogDisplayPageViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;

            DisplayAlertDialogCommand = new DelegateCommand(DisplayAlertDialog);
            DisplayErrorDialogCommand = new DelegateCommand(DisplayErrorDialog);
        }

        public DelegateCommand DisplayAlertDialogCommand { get; }

        public DelegateCommand DisplayErrorDialogCommand { get; }

        private void DisplayAlertDialog()
        {
            DialogService.DisplayAlert(AppResources.HelloWorldMessage);
        }

        private void DisplayErrorDialog()
        {
            try
            {
                throw new System.Exception();
            }
            catch (System.Exception ex)
            {
                DialogService.DisplayError(ex);
            }            
        }
    }
}
