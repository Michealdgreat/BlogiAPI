using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.BannerAd;

public class DeleteBannerAdCommand
{
    public Guid BannerId { get; set; }
    public UserInfo? CommandSender { get; set; }
}