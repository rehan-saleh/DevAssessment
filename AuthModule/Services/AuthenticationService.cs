using MockAuthentication.Models;
using MockAuthentication.Services;
using Prism.Logging;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AuthModule.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILogger Logger { get; }
        private IUserMockService UserMockService { get; }
        public AuthenticationService(ILogger logger, IUserMockService userMockService)
        {
            Logger = logger;
            UserMockService = userMockService;
        }

        public AuthenticationReponse Login(string username, string password)
        {
            var response = UserMockService.Login(username, password);
            if (response.IsAuthenticated)
            {
                Application.Current.Properties["access_token"] = response.AccessToken;
            }
            else
            {
                Logger.Log(response.Error);
            }
            return response;
        }

        public void LogOut()
        {
            Application.Current.Properties.Remove("access_token");
        }
    }
}
