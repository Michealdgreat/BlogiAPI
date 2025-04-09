using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Post;

public class DeletePostCommand  : ICommandBase
{
    public Guid PostId { get; set; }
    public UserInfo? CommandSender { get; set; }
}