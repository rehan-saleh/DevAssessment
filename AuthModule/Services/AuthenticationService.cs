using MockAuthentication.Models;
using MockAuthentication.Services;
using Prism.Logging;
using System.Threading.Tasks;
using Xamarin.Essentials;

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
                SecureStorage.SetAsync("access_token", response.AccessToken);
            }
            else
            {
                Logger.Log(response.Error);
            }
            return response;
        }

        public void LogOut()
        {
            SecureStorage.Remove("access_token");
        }

        public async Task<string> CheckForTokenValidationAsync()
        {
            string token = await SecureStorage.GetAsync("access_token");
            bool isTokenValid = UserMockService.CheckForTokenValidation(token);
            if (isTokenValid)
            {
                return token;
            }
            return string.Empty;
        }
    }
}
