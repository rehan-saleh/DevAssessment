using Prism.Services.Dialogs;

namespace DevAssessment.ViewModels
{
    public class AlertDialogPageViewModel : DialogBase
    {
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _message;

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Message"))
            {
                Message = parameters.GetValue<string>("Message");
            }
        }
    }
}
