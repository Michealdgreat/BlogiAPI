using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.User;

public class DeleteUserCommand : ICommandBase
{
    public Guid UserId { get; set; }
    
    public UserInfo? CommandSender { get; set; }
}