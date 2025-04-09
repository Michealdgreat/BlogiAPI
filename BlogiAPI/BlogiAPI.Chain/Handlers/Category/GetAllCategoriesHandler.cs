using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.CategoryService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Category
{
    public class GetAllCategoriesHandler(CategoryQueryService categoryQueryService) : QueryHandler<List<CategoryDto>, object>
    {
        private readonly CategoryQueryService _categoryQueryService = categoryQueryService;

        public override async Task<List<CategoryDto>?> HandleRequest(object? request)
        {
            var result = await _categoryQueryService.GetAllCategories();
            return result;
        }
    }
}