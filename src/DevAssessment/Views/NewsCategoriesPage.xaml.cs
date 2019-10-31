using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.NewsCategoriesPageTitle), nameof(NewsCategoriesPage), FontAwesomeSolidIconDictionary.List)]
namespace DevAssessment.Views
{
    public partial class NewsCategoriesPage : ContentPage
    {
        public NewsCategoriesPage()
        {
            InitializeComponent();
        }
    }
}
