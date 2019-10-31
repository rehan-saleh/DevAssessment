using Common.Localization;
using DevAssessment.Models;
using DevAssessment.Views;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class NewsCategoriesPageViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get; }

        public NewsCategoriesPageViewModel(INavigationService navigationService, IConnectivity connectivity, IDialogService dialogService) : base(connectivity, dialogService)
        {
            NavigationService = navigationService;

            var categories = new List<NewsCategory>()
            {
                new NewsCategory { CategoryName=AppResources.BusinessCategoryLabel, CategoryValue="business" },
                new NewsCategory { CategoryName=AppResources.EntertainmentCategoryLabel, CategoryValue="entertainment" },
                new NewsCategory { CategoryName=AppResources.GeneralCategoryLabel, CategoryValue="general" },
                new NewsCategory { CategoryName=AppResources.HealthCategoryLabel, CategoryValue="health" },
                new NewsCategory { CategoryName=AppResources.ScienceCategoryLabel, CategoryValue="science" },
                new NewsCategory { CategoryName=AppResources.SportsCategoryLabel, CategoryValue="sports" },
                new NewsCategory { CategoryName=AppResources.TechnologyCategoryLabel, CategoryValue="technology" }
            };

            Categories = new ObservableCollection<NewsCategory>(categories);

            NavigationCommand = new DelegateCommand<NewsCategory>(ExecuteNavigateCommand);
        }

        public IEnumerable<NewsCategory> Categories { get; }

        public DelegateCommand<NewsCategory> NavigationCommand { get; }

        private async void ExecuteNavigateCommand(NewsCategory newsCategory)
        {
            await NavigationService.NavigateAsync(nameof(HeadlinesListPage), ("Category", newsCategory.CategoryValue));
        }
    }
}
