using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Base;

public interface ICommandBase
{ 
    UserInfo? CommandSender { get; set; }
}