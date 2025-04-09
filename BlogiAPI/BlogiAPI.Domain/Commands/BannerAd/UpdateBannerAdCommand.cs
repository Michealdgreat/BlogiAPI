using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.BannerAd;

public class UpdateBannerAdCommand : ICommandBase
{
    public Guid BannerId { get; set; }
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? RedirectUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public UserInfo? CommandSender { get; set; }
}