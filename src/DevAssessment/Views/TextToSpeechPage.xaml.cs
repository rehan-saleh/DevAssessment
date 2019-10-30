using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.TextToSpeechPageTitle), nameof(TextToSpeechPage), FontAwesomeSolidIconDictionary.MicrophoneAlt)]
namespace DevAssessment.Views
{
    public partial class TextToSpeechPage : ContentPage
    {
        public TextToSpeechPage()
        {
            InitializeComponent();
        }
    }
}
