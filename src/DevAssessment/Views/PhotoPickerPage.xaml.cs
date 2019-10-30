using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.PhotoPickerPageTitle), nameof(PhotoPickerPage), FontAwesomeSolidIconDictionary.PhotoVideo)]
namespace DevAssessment.Views
{
    public partial class PhotoPickerPage : ContentPage
    {
        public PhotoPickerPage()
        {
            InitializeComponent();
        }
    }
}
