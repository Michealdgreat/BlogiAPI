using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.UserServices.QueryServices;

namespace BlogiAPI.Chain.Handlers.User
{
    public class GetUserByEmailHandler(UserQueryService userQueryService) : QueryHandler<UserDto, string>
    {
        private readonly UserQueryService _userQueryService = userQueryService;

        public override async Task<UserDto?> HandleRequest(string email)
        {
            var result = await _userQueryService.GetUserByEmail(email);
            return result;
        }
    }
}