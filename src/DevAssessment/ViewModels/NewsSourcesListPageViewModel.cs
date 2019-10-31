using DevAssessment.Models;
using DevAssessment.Services;
using Prism.AppModel;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class NewsSourcesListPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private INewsService NewsService { get; }
        public NewsSourcesListPageViewModel(INewsService newsService, IConnectivity connectivity, IDialogService dialogService) : base(connectivity, dialogService)
        {
            NewsService = newsService;
        }

        public IEnumerable<Source> NewsChannelList
        {
            get => _newsChannelList;
            set => SetProperty(ref _newsChannelList, value);
        }
        private IEnumerable<Source> _newsChannelList;

        public bool IsNewsSourceEnabled
        {
            get => _isNewsSourceEnabled;
            set => SetProperty(ref _isNewsSourceEnabled, value);
        }
        private bool _isNewsSourceEnabled;

        public void OnAppearing()
        {
            IsNewsSourceEnabled = true;

            GetNewsSourcesList();
        }

        public void OnDisappearing()
        {
            base.Dispose();
        }

        public override void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            base.Connectivity_ConnectivityChanged(sender, e);

            GetNewsSourcesList();
        }

        private async void GetNewsSourcesList()
        {
            IsBusy = true;
            if (!IsNotConnected)
            {
                var newsChannelList = await NewsService.GetNews();
                NewsChannelList = new ObservableCollection<Source>(newsChannelList.sources);
            }
            else
            {
                DisplayConnectionAlert();
            }
            IsBusy = false;
        }
    }
}
