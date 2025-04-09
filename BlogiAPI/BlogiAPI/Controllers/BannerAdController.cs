using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Controllers.Base;
using BlogiAPI.Domain.Commands.BannerAd;

namespace BlogiAPI.Controllers
{
    [Authorize]
    public class BannerAdController(BannerAdOrchestrator bannerAdOrchestrator) : ApiControllerBase
    {
        private readonly BannerAdOrchestrator _bannerAdOrchestrator = bannerAdOrchestrator;

        [HttpPost("CreateBannerAd")]
        public async Task<IActionResult> CreateBannerAd(CreateBannerAdCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _bannerAdOrchestrator.CreateBannerAd(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("UpdateBannerAd")]
        public async Task<IActionResult> UpdateBannerAd(UpdateBannerAdCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _bannerAdOrchestrator.UpdateBannerAd(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("DeleteBannerAd")]
        public async Task<IActionResult> DeleteBannerAd(DeleteBannerAdCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _bannerAdOrchestrator.DeleteBannerAd(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetBannerAdById/{bannerId:guid}")]
        public async Task<IActionResult> GetBannerAdById(Guid bannerId)
        {
            var result = await _bannerAdOrchestrator.GetBannerAdById(bannerId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetAllBannerAds")]
        public async Task<IActionResult> GetAllBannerAds()
        {
            var result = await _bannerAdOrchestrator.GetAllBannerAds();
            return Ok(result);
        }
    }
}