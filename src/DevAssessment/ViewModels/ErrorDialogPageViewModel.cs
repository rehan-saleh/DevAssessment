using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class ErrorDialogPageViewModel : BindableBase, IDialogAware
    {
        private ILogger Logger { get; }
        public ErrorDialogPageViewModel(ILogger logger)
        {
            Logger = logger;

            CloseDialogCommand = new DelegateCommand(() => RequestClose(null));
        }

        public string ExceptionMessage
        {
            get => _exceptionMessage;
            set => SetProperty(ref _exceptionMessage, value);
        }
        private string _exceptionMessage;

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
                ExceptionMessage = parameters.GetValue<string>("Message");
            }

            if (parameters.ContainsKey("Exception"))
            {
                var exception = parameters.GetValue<Exception>("Exception");
                Logger.Report(exception);
            }
        }
    }
}
