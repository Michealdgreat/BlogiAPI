using BlogiAPI.Domain.Commands.CarouselBanner;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.CarouselBannerService.CommandService
{
    public class CarouselBannerCommandService(ICarouselBannerRepository repository)
    {
        private readonly ICarouselBannerRepository _repository = repository;

        public async Task<OperationResult> CreateCarouselBanner(CreateCarouselBannerCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to create carousel banners");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.ImageUrl) || 
                    string.IsNullOrWhiteSpace(command.RedirectUrl))
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (createQuery, parameters) = SqlCommandFactory.CreateCarouselBannerCommand(
                    Guid.NewGuid(),
                    command.Title,
                    command.ImageUrl,
                    command.Description ?? "",
                    command.DisplayOrder,
                    command.RedirectUrl,
                    command.IsActive
                );

                await _repository.SaveData(createQuery, parameters);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error creating carousel banner: {e.Message}");
            }
        }

        public async Task<OperationResult> UpdateCarouselBanner(UpdateCarouselBannerCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to update carousel banners");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetCarouselBannerByIdQuery(command.CarouselId);
                var banner = await _repository.LoadOneData<CarouselBannerDto, object>(getQuery, getParams);

                if (banner == null)
                {
                    return OperationResult.Error("Carousel banner does not exist");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.ImageUrl) || 
                    string.IsNullOrWhiteSpace(command.RedirectUrl))
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (updateQuery, updateParams) = SqlCommandFactory.UpdateCarouselBannerCommand(
                    command.CarouselId,
                    command.Title,
                    command.ImageUrl,
                    command.Description ?? "",
                    command.DisplayOrder,
                    command.RedirectUrl,
                    command.IsActive
                );

                await _repository.SaveData(updateQuery, updateParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error updating carousel banner: {e.Message}");
            }
        }

        public async Task<OperationResult> DeleteCarouselBanner(DeleteCarouselBannerCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to delete carousel banners");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetCarouselBannerByIdQuery(command.CarouselId);
                var banner = await _repository.LoadOneData<CarouselBannerDto, object>(getQuery, getParams);

                if (banner == null)
                {
                    return OperationResult.Error("Carousel banner does not exist");
                }

                var (deleteQuery, deleteParams) = SqlCommandFactory.DeleteCarouselBannerCommand(command.CarouselId);
                await _repository.DeleteData(deleteQuery, deleteParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error deleting carousel banner: {e.Message}");
            }
        }
    }
}