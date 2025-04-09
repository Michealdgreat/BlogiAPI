
using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.User;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.UserServices.CommandServices;
using BlogiAPI.Domain.Services.UserServices.QueryServices;

namespace BlogiAPI.Client.Orchestrators;

public class UserOrchestrator(AuthService authService, UserCommandServices userCommandServices, UserQueryService userQueryService)
{
    private readonly AuthService _authService = authService;
    private readonly UserCommandServices _userCommandServices = userCommandServices;
    private readonly UserQueryService _userQueryService = userQueryService;

    public Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        var createAccountHandler = new CreateUserHandler(_userCommandServices);
        return createAccountHandler.HandleRequest(command);
    }

    public Task<OperationResult> UpdateUser(UpdateUserCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var updateUserHandler = new UpdateUserHandler(_userCommandServices);
        authorizationHandler.SetNext(updateUserHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<OperationResult> DeleteUser(DeleteUserCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var deleteUserHandler = new DeleteUserHandler(_userCommandServices);
        authorizationHandler.SetNext(deleteUserHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<UserDto?> GetUserById(Guid userId)
    {
        var getUserByIdHandler = new GetUserByIdHandler(_userQueryService);
        return getUserByIdHandler.HandleRequest(userId);
        
    }

    public Task<List<UserDto>?> GetAllUsers()
    {
        var getAllUsersHandler = new GetAllUsersHandler(_userQueryService);
        return getAllUsersHandler.HandleRequest(null);
    }


    public Task<UserDto?> GetUserByEmail(string email)
    {
        var getUserByEmailHandler = new GetUserByEmailHandler(_userQueryService);
        return getUserByEmailHandler.HandleRequest(email);
    }

    
}