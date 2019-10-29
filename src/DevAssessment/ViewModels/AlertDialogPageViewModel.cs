using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class AlertDialogPageViewModel : BindableBase, IDialogAware
    {
        public AlertDialogPageViewModel()
        {
            CloseDialogCommand = new DelegateCommand(() => RequestClose(null));
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _message;

        public event Action<IDialogParameters> RequestClose;

        public DelegateCommand CloseDialogCommand { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Message"))
            {
                Message = parameters.GetValue<string>("Message");
            }
        }
    }
}
