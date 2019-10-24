using AuthModule;
using AuthModule.Events;
using DevAssessment.Views;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;

namespace DevAssessment
{
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
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.Register<ILogger, ConsoleLoggingService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<AuthenticationModule>();
        }

        private async void NavigateAuthenticatedUser(string accessToken)
        {
            await NavigationService.NavigateAsync("MainPage");
        }

        private async void NavigateLoggedOutUser()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }
    }
}
