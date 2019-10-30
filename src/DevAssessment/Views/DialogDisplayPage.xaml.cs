using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.DialogDisplayPageTitle), nameof(DialogDisplayPage), FontAwesomeSolidIconDictionary.ExclamationCircle)]
namespace DevAssessment.Views
{
    public partial class DialogDisplayPage : ContentPage
    {
        public DialogDisplayPage()
        {
            InitializeComponent();
        }
    }
}
