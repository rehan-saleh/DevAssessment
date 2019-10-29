using AdminModule;
using AuthModule;
using AuthModule.Events;
using DevAssessment.Services;
using DevAssessment.ViewModels;
using DevAssessment.Views;
using DryIoc;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Linq;
using Xamarin.Forms;

namespace DevAssessment
{
    [AutoRegisterForNavigation]
    public partial class App
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected async override void OnInitialized()
        {
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<UserAuthenticatedEvent>().Subscribe(NavigateAuthenticatedUser);
            eventAggregator.GetEvent<UserLoggedOutEvent>().Subscribe(NavigateLoggedOutUser);

            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<ILogger, ConsoleLoggingService>();
            containerRegistry.Register<IMenuService, MenuService>();
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.RegisterDialog<AlertDialogPage, AlertDialogPageViewModel>();
            containerRegistry.RegisterDialog<ErrorDialogPage, ErrorDialogPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<AuthenticationModule>();

            Type adminModuleType = typeof(AdministratorModule);
            moduleCatalog.AddModule(new ModuleInfo(adminModuleType)
            {
                ModuleName = adminModuleType.Name,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        protected override Rules CreateContainerRules()
        {
            return base.CreateContainerRules().WithoutThrowOnRegisteringDisposableTransient();
        }

        private async void NavigateAuthenticatedUser(string accessToken)
        {
            await NavigationService.NavigateAsync("/MainPage/NavigationPage/HomePage", ("access_token", accessToken));
        }

        private async void NavigateLoggedOutUser()
        {
            var moduleList = Container.Resolve<IModuleCatalog>().Modules.ToList();
            var adminModule = moduleList.Find(x => x.ModuleName.Equals(nameof(AdministratorModule)));

            if (adminModule != null)
            {
                adminModule.State = ModuleState.NotStarted;
            }

            await NavigationService.NavigateAsync("/LoginPage");
        }
    }
}
