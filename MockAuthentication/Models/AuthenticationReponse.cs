namespace MockAuthentication.Models
{
    public class AuthenticationReponse
    {
        public bool IsAuthenticated { get; set; }
        public string AccessToken { get; set; }
        public string Error { get; set; }
    }
}
