using AuthModule.Events;
using AuthModule.Views;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase, IPageLifecycleAware
    {
        private IMenuService MenuService { get; }
        private INavigationService NavigationService { get; }
        private IEventAggregator EventAggregator { get; }

        public MainPageViewModel(INavigationService navigationService, IMenuService menuService, IEventAggregator eventAggregator)
        {
            MenuService = menuService;
            NavigationService = navigationService;
            EventAggregator = eventAggregator;

            Title = "Dev Assessment Test";
            Items = MenuService.Items;
            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);
            LogOutCommand = new DelegateCommand(ExecuteLogOutCommand);
        }

        public void OnAppearing()
        {
            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.TV || (Device.Idiom == TargetIdiom.Tablet && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape))
            {
                IsPresented = true;
            }
        }

        public void OnDisappearing()
        {
        }

        public string Title { get; }

        public bool IsPresented
        {
            get => _isPresented;
            set => SetProperty(ref _isPresented, value);
        }
        private bool _isPresented;

        public IEnumerable<Item> Items { get; set; }

        public DelegateCommand LogOutCommand { get; }

        public DelegateCommand<Item> NavigationCommand { get; }

        private async void OnNavigationCommandExecuted(Item item)
        {
            if (item.NavigationUri.Equals(nameof(LoginPage)))
            {
                LogOutCommand.Execute();
            }
            else
            {
                await NavigationService.NavigateAsync($"NavigationPage/{item.NavigationUri}");
            }
        }

        private void ExecuteLogOutCommand()
        {
            EventAggregator.GetEvent<UserLogoutRequestEvent>().Publish();
        }
    }
}
