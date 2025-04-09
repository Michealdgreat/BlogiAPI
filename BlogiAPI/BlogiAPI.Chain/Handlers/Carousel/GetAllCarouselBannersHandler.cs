using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.CarouselBannerService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Carousel
{
    public class GetAllCarouselBannersHandler(CarouselBannerQueryService carouselBannerQueryService) : QueryHandler<List<CarouselBannerDto>, object>
    {
        private readonly CarouselBannerQueryService _carouselBannerQueryService = carouselBannerQueryService;

        public override async Task<List<CarouselBannerDto>?> HandleRequest(object? request)
        {
            var result = await _carouselBannerQueryService.GetAllCarouselBanners();
            return result;
        }
    }
}