using Xamarin.Forms;

namespace DevAssessment.Views
{
    public partial class NewsReaderDialogPage : Frame
    {
        private bool HasNavigated { get; set; }

        public NewsReaderDialogPage()
        {
            InitializeComponent();
        }

        
        private void NewsWebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (HasNavigated)
            {
                e.Cancel = true;
            }
            else
            {
                HasNavigated = true;
            }
        }

        private void NewsWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            HasNavigated = true;
            Loader.IsVisible = false;
        }
    }
}
