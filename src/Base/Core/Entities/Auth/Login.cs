namespace Core.Entities.Auth
{
    public class LoginInput
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginOutput
    {
        public string Token { get; set; }
    }
}
