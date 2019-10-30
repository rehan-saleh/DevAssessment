using Common.Fonts;
using Common.Helpers;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("About", nameof(AboutPage), FontAwesomeSolidIconDictionary.InfoCircle)]
namespace DevAssessment.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
