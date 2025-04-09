using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.CarouselBanner;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.CarouselBannerService.CommandService;

namespace BlogiAPI.Chain.Handlers.Carousel
{
    public class CreateCarouselBannerHandler(CarouselBannerCommandService carouselBannerCommandService) : Handler<ICommandBase>
    {
        private readonly CarouselBannerCommandService _carouselBannerCommandService = carouselBannerCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is CreateCarouselBannerCommand command)
                {
                    var result = await _carouselBannerCommandService.CreateCarouselBanner(command);
                    return result;
                }
            }
            catch (Exception)
            {
                return OperationResult.Error("Operation failed");
            }

            return OperationResult.Error("Operation failed");
        }
    }
}