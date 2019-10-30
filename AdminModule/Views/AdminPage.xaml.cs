using AdminModule.Views;
using Common.Fonts;
using Common.Helpers;
using Xamarin.Forms;

[assembly: MenuItem("Admin", nameof(AdminPage), FontAwesomeSolidIconDictionary.User)]
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
