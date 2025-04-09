using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.BannerAd;
using BlogiAPI.Domain.Commands.BannerAd;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.BannerAdService.CommandService;
using BlogiAPI.Domain.Services.BannerAdService.QueryServices;

namespace BlogiAPI.Client.Orchestrators;

public class BannerAdOrchestrator(BannerAdCommandService bannerAdCommandService, BannerAdQueryService bannerAdQueryService, AuthService authService)
{
    private readonly AuthService _authService = authService;
    private readonly BannerAdCommandService _bannerAdCommandService = bannerAdCommandService;
    private readonly BannerAdQueryService _bannerAdQueryService = bannerAdQueryService;

    public Task<OperationResult> CreateBannerAd(CreateBannerAdCommand command)
    {
        var createBannerAdHandler = new CreateBannerAdHandler(_bannerAdCommandService);
        return createBannerAdHandler.HandleRequest(command);
    }

    public Task<OperationResult> UpdateBannerAd(UpdateBannerAdCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var updateBannerAdHandler = new UpdateBannerAdHandler(_bannerAdCommandService);
        authorizationHandler.SetNext(updateBannerAdHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<OperationResult> DeleteBannerAd(DeleteBannerAdCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var deleteBannerAdHandler = new DeleteBannerAdHandler(_bannerAdCommandService);
        authorizationHandler.SetNext(deleteBannerAdHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<BannerAdDto?> GetBannerAdById(Guid bannerId)
    {
        var getBannerAdByIdHandler = new GetBannerAdByIdHandler(_bannerAdQueryService);
        return getBannerAdByIdHandler.HandleRequest(bannerId);
    }

    public Task<List<BannerAdDto>?> GetAllBannerAds()
    {
        var getAllBannerAdsHandler = new GetAllBannerAdsHandler(_bannerAdQueryService);
        return getAllBannerAdsHandler.HandleRequest(null);
    }
}