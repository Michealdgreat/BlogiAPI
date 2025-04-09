using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.RoleService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Role
{
    public class GetAllRolesHandler(RoleQueryService roleQueryService) : QueryHandler<List<RoleDto>, object>
    {
        private readonly RoleQueryService _roleQueryService = roleQueryService;

        public override async Task<List<RoleDto>?> HandleRequest(object? request)
        {
            var result = await _roleQueryService.GetAllRoles();
            return result;
        }
    }
}