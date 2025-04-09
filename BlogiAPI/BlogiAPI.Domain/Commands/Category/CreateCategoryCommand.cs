using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Category;

public class CreateCategoryCommand : ICommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public UserInfo? CommandSender { get; set; }
}