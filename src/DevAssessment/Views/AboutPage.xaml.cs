using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.AboutPageTitle), nameof(AboutPage), FontAwesomeSolidIconDictionary.InfoCircle)]
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
