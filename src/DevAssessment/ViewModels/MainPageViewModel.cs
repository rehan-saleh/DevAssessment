using AdminModule;
using AuthModule.Events;
using AuthModule.Services;
using AuthModule.Views;
using DevAssessment.Models;
using DevAssessment.Services;
using MockAuthentication.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase, IPageLifecycleAware, IInitialize
    {
        private IMenuService MenuService { get; }
        public IModuleManager ModuleManager { get; }
        private INavigationService NavigationService { get; }
        private IEventAggregator EventAggregator { get; }
        private string AccessToken { get; set; }
        private LoggedInUser LoggedInUser { get; set; }

        public MainPageViewModel(INavigationService navigationService, IMenuService menuService, IEventAggregator eventAggregator, IAuthenticationService authenticationService, IModuleManager moduleManager)
        {
            MenuService = menuService;
            NavigationService = navigationService;
            ModuleManager = moduleManager;
            EventAggregator = eventAggregator;

            Title = "Dev Assessment Test";
            Items = MenuService.Items;
            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);
            LogOutCommand = new DelegateCommand(ExecuteLogOutCommand);
        }

        public void Initialize(INavigationParameters parameters)
        {
            AccessToken = parameters.GetValue<string>("access_token");
            LoggedInUser = new LoggedInUser(AccessToken);
        }

        public void OnAppearing()
        {
            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.TV || (Device.Idiom == TargetIdiom.Tablet && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape))
            {
                IsPresented = true;
            }

            if (LoggedInUser != null && LoggedInUser.Role.Equals(nameof(Role.Admin)))
            {
                ModuleManager.LoadModule(nameof(AdministratorModule));
            }

            MenuService.ClearMenuItems();
            MenuService.LoadMenuItems();
            
            Items = new ObservableCollection<Item>(MenuService.Items);
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

        public IEnumerable<Item> Items { 
            get => items; 
            set => SetProperty(ref items, value); 
        }
        private IEnumerable<Item> items;

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
