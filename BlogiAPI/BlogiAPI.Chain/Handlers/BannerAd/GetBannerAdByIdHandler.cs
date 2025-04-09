using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.BannerAdService.QueryServices;

namespace BlogiAPI.Chain.Handlers.BannerAd
{
    public class GetBannerAdByIdHandler(BannerAdQueryService bannerAdQueryService) : QueryHandler<BannerAdDto, Guid>
    {
        private readonly BannerAdQueryService _bannerAdQueryService = bannerAdQueryService;

        public override async Task<BannerAdDto?> HandleRequest(Guid request)
        {
            var result = await _bannerAdQueryService.GetBannerAdById(request);
            return result;
        }
    }
}