using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.User;

public class UpdateUserCommand : ICommandBase
{
    public Guid UserId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
   // public string? Password { get; set; }
    public string? Address { get; set; }

    public UserInfo? CommandSender { get; set; }
}