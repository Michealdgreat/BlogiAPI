using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.UserServices.QueryServices;

public class UserQueryService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<UserDto?> GetUserById(Guid userId)
    {
        try
        {
            var (getUserQuery, getUserParameter) = SqlQueryFactory.GetUserByIdQuery(userId);

            var user = await _repository.LoadOneData<UserDto, object>(getUserQuery, getUserParameter);

            return user;
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    public async Task<UserDto?> GetUserByEmail(string userEmail)
    {
        try
        {
            var (getUserQuery, getUserParameter) = SqlQueryFactory.GetUserByEmailQuery(userEmail);

            var user = await _repository.LoadOneData<UserDto, object>(getUserQuery, getUserParameter);

            return user;
        }
        catch (Exception)
        {
            return null;
        }
    }
    

    public async Task<List<UserDto>?> GetUsers()
    {
        try
        {
            var(getAllUsersQuery, getAllUsersParameter) = SqlQueryFactory.GetAllUsersQuery();

            var result =await _repository.LoadData<UserDto, object>(getAllUsersQuery, getAllUsersParameter);
            
            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }
}