using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.CategoryService.QueryServices;

public class CategoryQueryService(ICategoryRepository repository)
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<CategoryDto?> GetCategoryById(Guid categoryId)
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetCategoryByIdQuery(categoryId);
            var category = await _repository.LoadOneData<CategoryDto, object>(getQuery, getParams);
            return category;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<CategoryDto>?> GetAllCategories()
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetAllCategoriesQuery();
            var categories = await _repository.LoadData<CategoryDto, object>(getQuery, getParams);
            return categories;
        }
        catch (Exception)
        {
            return null;
        }
    }
}