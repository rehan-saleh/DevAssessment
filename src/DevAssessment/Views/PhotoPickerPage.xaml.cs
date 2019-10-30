using Common.Fonts;
using Common.Helpers;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("Photo Picker", nameof(PhotoPickerPage), FontAwesomeSolidIconDictionary.PhotoVideo)]
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
