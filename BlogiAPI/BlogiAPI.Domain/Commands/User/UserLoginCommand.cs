namespace BlogiAPI.Domain.Commands.User
{
    public class UserLoginCommand
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}