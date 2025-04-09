using BlogiAPI.Domain.Commands.Category;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.CategoryService.CommandService
{
    public class CategoryCommandService(ICategoryRepository repository)
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<OperationResult> CreateCategory(CreateCategoryCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to create categories");
                }

                if (string.IsNullOrWhiteSpace(command.Name))
                {
                    return OperationResult.Error("Please provide a valid category name");
                }

                var (createQuery, parameters) = SqlCommandFactory.CreateCategoryCommand(
                    Guid.NewGuid(),
                    command.Name,
                    command.Description
                );

                await _repository.SaveData(createQuery, parameters);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error creating category: {e.Message}");
            }
        }

        public async Task<OperationResult> UpdateCategory(UpdateCategoryCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to update categories");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetCategoryByIdQuery(command.CategoryId);
                var category = await _repository.LoadOneData<CategoryDto, object>(getQuery, getParams);

                if (category == null)
                {
                    return OperationResult.Error("Category does not exist");
                }

                if (string.IsNullOrWhiteSpace(command.Name))
                {
                    return OperationResult.Error("Please provide a valid category name");
                }

                var (updateQuery, updateParams) = SqlCommandFactory.UpdateCategoryCommand(
                    command.CategoryId,
                    command.Name,
                    command.Description ?? ""
                );

                await _repository.SaveData(updateQuery, updateParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error updating category: {e.Message}");
            }
        }

        public async Task<OperationResult> DeleteCategory(DeleteCategoryCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to delete categories");
                }

                var (getQuery, getParams) = SqlQueryFactory.GetCategoryByIdQuery(command.CategoryId);
                var category = await _repository.LoadOneData<CategoryDto, object>(getQuery, getParams);

                if (category == null)
                {
                    return OperationResult.Error("Category does not exist");
                }

                var (deleteQuery, deleteParams) = SqlCommandFactory.DeleteCategoryCommand(command.CategoryId);
                await _repository.DeleteData(deleteQuery, deleteParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error deleting category: {e.Message}");
            }
        }
    }
}