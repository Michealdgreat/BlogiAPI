using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.BannerAd;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.BannerAdService.CommandService;

namespace BlogiAPI.Chain.Handlers.BannerAd
{
    public class CreateBannerAdHandler(BannerAdCommandService bannerAdCommandService) : Handler<ICommandBase>
    {
        private readonly BannerAdCommandService _bannerAdCommandService = bannerAdCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is CreateBannerAdCommand command)
                {
                    var result = await _bannerAdCommandService.CreateBannerAd(command);
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