using Common.Localization;
using DevAssessment.Extensions;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class ViewModelBase : BindableBase, IDisposable
    {
        public IDialogService DialogService { get; }

        public ViewModelBase(IConnectivity connectivity, IDialogService dialogService)
        {
            DialogService = dialogService;

            connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        public bool IsNotConnected { get; set; }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        private bool _isBusy;

        public virtual void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        public void DisplayConnectionAlert()
        {
            if (IsNotConnected)
            {
                DialogService.DisplayAlert(AppResources.InternetConnectionNotAvailableMessage);
            }
        }

        public void Dispose()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
    }
}
