using AuthModule.Events;
using AuthModule.Services;
using MockAuthentication.Models;
using MockAuthentication.Services;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;

namespace AuthModule
{
    [AutoRegisterForNavigation]
    public class AuthenticationModule : IModule
    {
        private IAuthenticationService AuthenticationService { get; set; }
        private IEventAggregator EventAggregator { get; set; }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            AuthenticationService = containerProvider.Resolve<IAuthenticationService>();
            EventAggregator = containerProvider.Resolve<IEventAggregator>();

            EventAggregator.GetEvent<UserLogoutRequestEvent>().Subscribe(ExecuteLogoutRequest);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IUserMockService, UserMockService>();
            containerRegistry.Register<IJwtService, JwtService>();
            containerRegistry.Register<IAuthContainer, JwtContainer>();
        }

        private void ExecuteLogoutRequest()
        {
            AuthenticationService.LogOut();

            EventAggregator.GetEvent<UserLoggedOutEvent>().Publish();
        }
    }
}
