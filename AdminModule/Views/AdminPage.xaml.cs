using AdminModule.Views;
using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.AdminPageTitle), nameof(AdminPage), FontAwesomeSolidIconDictionary.User)]
namespace AdminModule.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
    }
}
