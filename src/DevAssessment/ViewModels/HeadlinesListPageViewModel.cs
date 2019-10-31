using DevAssessment.Models;
using DevAssessment.Services;
using Prism.AppModel;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using DevAssessment.Extensions;

namespace DevAssessment.ViewModels
{
    public class HeadlinesListPageViewModel : ViewModelBase, IAutoInitialize, IPageLifecycleAware
    {
        private INewsService NewsService { get; }

        public HeadlinesListPageViewModel(INewsService newsService, IDialogService dialogService, IConnectivity connectivity) : base(connectivity, dialogService)
        {
            NewsService = newsService;

            OpenNewsReaderDialogCommand = new DelegateCommand<Article>(OpenNewsReaderDialog);
        }

        [AutoInitialize("category", true)]
        public string NewsCategory
        {
            get => _newsCategory;
            set => SetProperty(ref _newsCategory, value);
        }
        private string _newsCategory;

        public IEnumerable<Article> ArticleList
        {
            get => _articleList;
            set => SetProperty(ref _articleList, value);
        }
        private IEnumerable<Article> _articleList;

        public DelegateCommand<Article> OpenNewsReaderDialogCommand { get; }

        public void OnAppearing()
        {
            GetTopHeadlines();
        }

        public void OnDisappearing()
        {
            base.Dispose();
        }

        public override void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            base.Connectivity_ConnectivityChanged(sender, e);

            GetTopHeadlines();
        }

        private async void GetTopHeadlines()
        {
            IsBusy = true;
            if (!IsNotConnected)
            {
                NewsArticles newsArticlesList = await NewsService.GetHeadlines(NewsCategory);
                ArticleList = new ObservableCollection<Article>(newsArticlesList.articles);
            }
            else
            {
                DisplayConnectionAlert();
            }
            IsBusy = false;
        }

        private void OpenNewsReaderDialog(Article article)
        {
            DialogService.DisplayNews(article.url);
        }
    }
}
