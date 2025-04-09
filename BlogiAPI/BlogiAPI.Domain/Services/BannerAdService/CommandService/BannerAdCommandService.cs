using BlogiAPI.Domain.Commands.BannerAd;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.BannerAdService.CommandService
{
    public class BannerAdCommandService(IBannerAdRepository repository)
    {
        private readonly IBannerAdRepository _repository = repository;

        public async Task<OperationResult> CreateBannerAd(CreateBannerAdCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to create banner ads");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.ImageUrl) || 
                    string.IsNullOrWhiteSpace(command.RedirectUrl))
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (createQuery, parameters) = SqlCommandFactory.CreateBannerAdCommand(
                    Guid.NewGuid(),
                    command.Title,
                    command.ImageUrl,
                    command.RedirectUrl,
                    command.StartDate,
                    command.EndDate,
                    command.IsActive
                );

                await _repository.SaveData(createQuery, parameters);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error creating banner ad: {e.Message}");
            }
        }

        public async Task<OperationResult> UpdateBannerAd(UpdateBannerAdCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to update banner ads");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetBannerAdByIdQuery(command.BannerId);
                var banner = await _repository.LoadOneData<BannerAdDto, object>(getQuery, getParams);

                if (banner == null)
                {
                    return OperationResult.Error("Banner ad does not exist");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.ImageUrl) || 
                    string.IsNullOrWhiteSpace(command.RedirectUrl))
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (updateQuery, updateParams) = SqlCommandFactory.UpdateBannerAdCommand(
                    command.BannerId,
                    command.Title,
                    command.ImageUrl,
                    command.RedirectUrl,
                    command.StartDate,
                    command.EndDate,
                    command.IsActive
                );

                await _repository.SaveData(updateQuery, updateParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error updating banner ad: {e.Message}");
            }
        }

        public async Task<OperationResult> DeleteBannerAd(DeleteBannerAdCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to delete banner ads");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetBannerAdByIdQuery(command.BannerId);
                var banner = await _repository.LoadOneData<BannerAdDto, object>(getQuery, getParams);

                if (banner == null)
                {
                    return OperationResult.Error("Banner ad does not exist");
                }

                var (deleteQuery, deleteParams) = SqlCommandFactory.DeleteBannerAdCommand(command.BannerId);
                await _repository.DeleteData(deleteQuery, deleteParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error deleting banner ad: {e.Message}");
            }
        }
    }
}