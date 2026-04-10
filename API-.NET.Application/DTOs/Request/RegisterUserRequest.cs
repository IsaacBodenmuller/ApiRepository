namespace API_.NET.Application.DTOs.Request
{
    public class RegisterUserRequest
    {  
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProfileId { get; set; }
    }
}
