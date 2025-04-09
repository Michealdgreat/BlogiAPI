using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.Carousel;
using BlogiAPI.Domain.Commands.CarouselBanner;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.CarouselBannerService.CommandService;
using BlogiAPI.Domain.Services.CarouselBannerService.QueryServices;

namespace BlogiAPI.Client.Orchestrators;

public class CarouselBannerOrchestrator(CarouselBannerCommandService carouselBannerCommandService, CarouselBannerQueryService carouselBannerQueryService, AuthService authService)
{
    private readonly AuthService _authService = authService;
    private readonly CarouselBannerCommandService _carouselBannerCommandService = carouselBannerCommandService;
    private readonly CarouselBannerQueryService _carouselBannerQueryService = carouselBannerQueryService;

    public Task<OperationResult> CreateCarouselBanner(CreateCarouselBannerCommand command)
    {
        var createCarouselBannerHandler = new CreateCarouselBannerHandler(_carouselBannerCommandService);
        return createCarouselBannerHandler.HandleRequest(command);
    }

    public Task<OperationResult> UpdateCarouselBanner(UpdateCarouselBannerCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var updateCarouselBannerHandler = new UpdateCarouselBannerHandler(_carouselBannerCommandService);
        authorizationHandler.SetNext(updateCarouselBannerHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<OperationResult> DeleteCarouselBanner(DeleteCarouselBannerCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var deleteCarouselBannerHandler = new DeleteCarouselBannerHandler(_carouselBannerCommandService);
        authorizationHandler.SetNext(deleteCarouselBannerHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<CarouselBannerDto?> GetCarouselBannerById(Guid carouselId)
    {
        var getCarouselBannerByIdHandler = new GetCarouselBannerByIdHandler(_carouselBannerQueryService);
        return getCarouselBannerByIdHandler.HandleRequest(carouselId);
    }

    public Task<List<CarouselBannerDto>?> GetAllCarouselBanners()
    {
        var getAllCarouselBannersHandler = new GetAllCarouselBannersHandler(_carouselBannerQueryService);
        return getAllCarouselBannersHandler.HandleRequest(null);
    }
}