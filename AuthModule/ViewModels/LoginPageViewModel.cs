using AuthModule.Events;
using AuthModule.Services;
using MockAuthentication.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AuthModule.ViewModels
{
    public class LoginPageViewModel : BindableBase, IPageLifecycleAware
    {
        private IEventAggregator EventAggregator { get; }
        private IAuthenticationService AuthenticationService { get; }

        public LoginPageViewModel(IAuthenticationService authenticationService, IEventAggregator eventAggregator)
        {
            AuthenticationService = authenticationService;
            EventAggregator = eventAggregator;

            OnLogin = new DelegateCommand(ExecuteLoginCommand);
        }

        public async void OnAppearing()
        {
            string accessToken = await AuthenticationService.CheckForTokenValidationAsync();
            if (!string.IsNullOrEmpty(accessToken))
            {
                EventAggregator.GetEvent<UserAuthenticatedEvent>().Publish(accessToken);
            }
        }

        public void OnDisappearing()
        {
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        private string _errorMessage;

        public bool Busy
        {
            get => _busy;
            set => SetProperty(ref _busy, value);
        }
        private bool _busy;

        public DelegateCommand OnLogin { get; }

        private void ExecuteLoginCommand()
        {
            ErrorMessage = string.Empty;
            if (ValidateEmail())
            {
                Busy = true;
                AuthenticationReponse response = AuthenticationService.Login(Email, Password);
                if (response.IsAuthenticated)
                {
                    EventAggregator.GetEvent<UserAuthenticatedEvent>().Publish(response.AccessToken);
                }
                else
                {
                    ErrorMessage = response.Error;
                }
                Busy = false;
            }
        }

        private bool ValidateEmail()
        {
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Email))
            {
                SetErrorMessage();
                return false;
            }
            return true;
        }


        private void SetErrorMessage()
        {
            ErrorMessage = "Invalid username or password.";
        }
    }
}
