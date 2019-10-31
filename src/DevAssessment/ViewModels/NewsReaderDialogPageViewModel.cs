using Prism.Services.Dialogs;

namespace DevAssessment.ViewModels
{
    public class NewsReaderDialogPageViewModel : DialogBase
    {
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }
        private string _url;

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("NewsReaderDialogUrl"))
            {
                Url = parameters.GetValue<string>("NewsReaderDialogUrl");
            }
        }
    }
}
