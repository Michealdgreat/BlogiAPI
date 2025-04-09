using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.RoleService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Role
{
    public class GetRoleByNameHandler(RoleQueryService roleQueryService) : QueryHandler<RoleDto, string>
    {
        private readonly RoleQueryService _roleQueryService = roleQueryService;

        public override async Task<RoleDto?> HandleRequest(string request)
        {
            var result = await _roleQueryService.GetRoleByName(request);
            return result;
        }
    }
}