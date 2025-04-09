using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Post;

public class CreatePostCommand  : ICommandBase
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public bool IsPublished { get; set; }
    public UserInfo? CommandSender { get; set; }
}