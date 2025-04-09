using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.CarouselBannerService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Carousel
{
    public class GetCarouselBannerByIdHandler(CarouselBannerQueryService carouselBannerQueryService) : QueryHandler<CarouselBannerDto, Guid>
    {
        private readonly CarouselBannerQueryService _carouselBannerQueryService = carouselBannerQueryService;

        public override async Task<CarouselBannerDto?> HandleRequest(Guid request)
        {
            var result = await _carouselBannerQueryService.GetCarouselBannerById(request);
            return result;
        }
    }
}