using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.BannerAdService.QueryServices;

public class BannerAdQueryService(IBannerAdRepository repository)
{
    private readonly IBannerAdRepository _repository = repository;

    public async Task<BannerAdDto?> GetBannerAdById(Guid bannerId)
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetBannerAdByIdQuery(bannerId);
            var bannerAd = await _repository.LoadOneData<BannerAdDto, object>(getQuery, getParams);
            return bannerAd;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<BannerAdDto>?> GetAllBannerAds()
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetAllBannerAdsQuery();
            var bannerAds = await _repository.LoadData<BannerAdDto, object>(getQuery, getParams);
            return bannerAds;
        }
        catch (Exception)
        {
            return null;
        }
    }
}