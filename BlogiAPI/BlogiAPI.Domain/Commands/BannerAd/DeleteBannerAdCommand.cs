using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.BannerAd;

public class DeleteBannerAdCommand : ICommandBase
{
    public Guid BannerId { get; set; }
    public UserInfo? CommandSender { get; set; }
}