using Common.Fonts;
using Common.Helpers;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("Device Orientation", nameof(DeviceOrientationPage), FontAwesomeSolidIconDictionary.Mobile)]
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
