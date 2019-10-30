using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.DeviceOrientationPageTitle), nameof(DeviceOrientationPage), FontAwesomeSolidIconDictionary.Mobile)]
namespace DevAssessment.Views
{
    public partial class DeviceOrientationPage : ContentPage
    {
        public DeviceOrientationPage()
        {
            InitializeComponent();
        }
    }
}
