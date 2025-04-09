using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.Category;
using BlogiAPI.Domain.Commands.Category;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.CategoryService.CommandService;
using BlogiAPI.Domain.Services.CategoryService.QueryServices;

namespace BlogiAPI.Client.Orchestrators;

public class CategoryOrchestrator(CategoryCommandService categoryCommandService, CategoryQueryService categoryQueryService, AuthService authService)
{
    private readonly AuthService _authService = authService;
    private readonly CategoryCommandService _categoryCommandService = categoryCommandService;
    private readonly CategoryQueryService _categoryQueryService = categoryQueryService;

    public Task<OperationResult> CreateCategory(CreateCategoryCommand command)
    {
        var createCategoryHandler = new CreateCategoryHandler(_categoryCommandService);
        return createCategoryHandler.HandleRequest(command);
    }

    public Task<OperationResult> UpdateCategory(UpdateCategoryCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var updateCategoryHandler = new UpdateCategoryHandler(_categoryCommandService);
        authorizationHandler.SetNext(updateCategoryHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<OperationResult> DeleteCategory(DeleteCategoryCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var deleteCategoryHandler = new DeleteCategoryHandler(_categoryCommandService);
        authorizationHandler.SetNext(deleteCategoryHandler);
        return authorizationHandler.HandleRequest(command);
    }
    

    public Task<List<CategoryDto>?> GetAllCategories()
    {
        var getAllCategoriesHandler = new GetAllCategoriesHandler(_categoryQueryService);
        return getAllCategoriesHandler.HandleRequest(null);
    }
}