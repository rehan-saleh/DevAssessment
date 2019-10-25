using AdminModule.Views;
using Helpers;
using Xamarin.Forms;

[assembly: MenuItem("Admin", nameof(AdminPage))]
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
