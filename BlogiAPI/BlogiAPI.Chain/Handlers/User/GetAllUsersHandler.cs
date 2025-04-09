using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.UserServices.QueryServices;

namespace BlogiAPI.Chain.Handlers.User
{
    public class GetAllUsersHandler(UserQueryService userQueryService) : QueryHandler<List<UserDto>, object>
    {
        private readonly UserQueryService _userQueryService = userQueryService;

        public override async Task<List<UserDto>?> HandleRequest(object? request)
        {
            var result = await _userQueryService.GetUsers();
            return result;
        }
    }
}