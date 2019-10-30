using Common.Fonts;
using Common.Helpers;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("Text To Speech", nameof(TextToSpeechPage), FontAwesomeSolidIconDictionary.MicrophoneAlt)]
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
