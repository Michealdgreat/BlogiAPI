using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.Role;

public class UpdateRoleCommand : ICommandBase
{
    public Guid RoleId { get; set; }
    public string? Name { get; set; }
    public UserInfo? CommandSender { get; set; }
}