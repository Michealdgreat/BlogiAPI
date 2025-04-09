using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Commands.CarouselBanner;

public class DeleteCarouselBannerCommand : ICommandBase
{
    public Guid CarouselId { get; set; }
    public UserInfo? CommandSender { get; set; }
}