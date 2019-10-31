using Common.Fonts;
using Common.Helpers;
using Common.Localization;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem(nameof(AppResources.NewsListPageTitle), nameof(NewsSourcesListPage), FontAwesomeSolidIconDictionary.Newspaper)]
namespace DevAssessment.Views
{
    public partial class NewsSourcesListPage : ContentPage
    {
        public NewsSourcesListPage()
        {
            InitializeComponent();
        }
    }
}
