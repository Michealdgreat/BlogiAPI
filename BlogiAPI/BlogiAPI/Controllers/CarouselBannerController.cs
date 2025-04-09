using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Controllers.Base;
using BlogiAPI.Domain.Commands.CarouselBanner;

namespace BlogiAPI.Controllers
{
    [Authorize]
    public class CarouselBannerController(CarouselBannerOrchestrator carouselBannerOrchestrator) : ApiControllerBase
    {
        private readonly CarouselBannerOrchestrator _carouselBannerOrchestrator = carouselBannerOrchestrator;

        [HttpPost("CreateCarouselBanner")]
        public async Task<IActionResult> CreateCarouselBanner(CreateCarouselBannerCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _carouselBannerOrchestrator.CreateCarouselBanner(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("UpdateCarouselBanner")]
        public async Task<IActionResult> UpdateCarouselBanner(UpdateCarouselBannerCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _carouselBannerOrchestrator.UpdateCarouselBanner(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("DeleteCarouselBanner")]
        public async Task<IActionResult> DeleteCarouselBanner(DeleteCarouselBannerCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _carouselBannerOrchestrator.DeleteCarouselBanner(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetCarouselBannerById/{carouselId:guid}")]
        public async Task<IActionResult> GetCarouselBannerById(Guid carouselId)
        {
            var result = await _carouselBannerOrchestrator.GetCarouselBannerById(carouselId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetAllCarouselBanners")]
        public async Task<IActionResult> GetAllCarouselBanners()
        {
            var result = await _carouselBannerOrchestrator.GetAllCarouselBanners();
            return Ok(result);
        }
    }
}