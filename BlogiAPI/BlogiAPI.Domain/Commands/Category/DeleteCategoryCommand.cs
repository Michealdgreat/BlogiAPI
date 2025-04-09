using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Category;

public class DeleteCategoryCommand  : ICommandBase
{
    public Guid CategoryId { get; set; }
    public UserInfo? CommandSender { get; set; }
}