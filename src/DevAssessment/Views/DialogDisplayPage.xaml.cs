using Common.Fonts;
using Common.Helpers;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("Dialog Demo", nameof(DialogDisplayPage), FontAwesomeSolidIconDictionary.ExclamationCircle)]
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
