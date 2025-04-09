using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.CarouselBannerService.QueryServices;

public class CarouselBannerQueryService(ICarouselBannerRepository repository)
{
    private readonly ICarouselBannerRepository _repository = repository;

    public async Task<CarouselBannerDto?> GetCarouselBannerById(Guid carouselId)
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetCarouselBannerByIdQuery(carouselId);
            var carouselBanner = await _repository.LoadOneData<CarouselBannerDto, object>(getQuery, getParams);
            return carouselBanner;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<CarouselBannerDto>?> GetAllCarouselBanners()
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetAllCarouselBannersQuery();
            var carouselBanners = await _repository.LoadData<CarouselBannerDto, object>(getQuery, getParams);
            return carouselBanners;
        }
        catch (Exception)
        {
            return null;
        }
    }
}