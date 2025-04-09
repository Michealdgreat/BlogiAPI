using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.Category;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.CategoryService.CommandService;

namespace BlogiAPI.Chain.Handlers.Category
{
    public class UpdateCategoryHandler(CategoryCommandService categoryCommandService) : Handler<ICommandBase>
    {
        private readonly CategoryCommandService _categoryCommandService = categoryCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is UpdateCategoryCommand command)
                {
                    var result = await _categoryCommandService.UpdateCategory(command);
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