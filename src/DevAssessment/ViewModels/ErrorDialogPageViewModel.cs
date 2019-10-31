using Prism.Logging;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class ErrorDialogPageViewModel : DialogBase
    {
        private ILogger Logger { get; }

        public ErrorDialogPageViewModel(ILogger logger)
        {
            Logger = logger;
        }

        public string ExceptionMessage
        {
            get => _exceptionMessage;
            set => SetProperty(ref _exceptionMessage, value);
        }
        private string _exceptionMessage;

        public override void OnDialogOpened(IDialogParameters parameters)
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
