using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.CarouselBanner;

public class UpdateCarouselBannerCommand : ICommandBase
{
    public Guid CarouselId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public string RedirectUrl { get; set; }
    public bool IsActive { get; set; }
    public UserInfo? CommandSender { get; set; }
}