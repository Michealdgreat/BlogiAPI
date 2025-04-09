using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.BannerAdService.QueryServices;

namespace BlogiAPI.Chain.Handlers.BannerAd
{
    public class GetAllBannerAdsHandler(BannerAdQueryService bannerAdQueryService) : QueryHandler<List<BannerAdDto>, object>
    {
        private readonly BannerAdQueryService _bannerAdQueryService = bannerAdQueryService;

        public override async Task<List<BannerAdDto>?> HandleRequest(object? request)
        {
            var result = await _bannerAdQueryService.GetAllBannerAds();
            return result;
        }
    }
}