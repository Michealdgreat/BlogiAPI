using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.RoleService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Role
{
    public class GetRoleByIdHandler(RoleQueryService roleQueryService) : QueryHandler<RoleDto, Guid>
    {
        private readonly RoleQueryService _roleQueryService = roleQueryService;

        public override async Task<RoleDto?> HandleRequest(Guid request)
        {
            var result = await _roleQueryService.GetRoleById(request);
            return result;
        }
    }
}