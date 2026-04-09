namespace API_.NET.Application.DTOs.Request
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
