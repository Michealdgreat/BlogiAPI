using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.UserServices.QueryServices;

namespace BlogiAPI.Chain.Handlers.User;

public class GetUserByIdHandler(UserQueryService userQueryService) : QueryHandler<UserDto, Guid>
{
    private readonly UserQueryService _userQueryService = userQueryService;
    
    public override async Task<UserDto?> HandleRequest(Guid request)
    {
        var result = await _userQueryService.GetUserById(request);
        
        return result;
    }
}