using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.Role; 
using BlogiAPI.Domain.Commands.Role; 
using BlogiAPI.Domain.DTOs; 
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.RoleService.CommandService;
using BlogiAPI.Domain.Services.RoleService.QueryServices;

namespace BlogiAPI.Client.Orchestrators
{
    public class RoleOrchestrator(RoleCommandService roleCommandService, RoleQueryService roleQueryService, AuthService authService)
    {
        private readonly AuthService _authService = authService;

        public Task<OperationResult> CreateRole(CreateRoleCommand command)
        {
            var authorizationHandler = new AuthorizationHandler(_authService); 
            var createRoleHandler = new CreateRoleHandler(roleCommandService);
            authorizationHandler.SetNext(createRoleHandler);
            return authorizationHandler.HandleRequest(command);
        }

        public Task<OperationResult> UpdateRole(UpdateRoleCommand command)
        {
            var authorizationHandler = new AuthorizationHandler(_authService); 
            var updateRoleHandler = new UpdateRoleHandler(roleCommandService);
            authorizationHandler.SetNext(updateRoleHandler);
            return authorizationHandler.HandleRequest(command);
        }
       
        public Task<RoleDto?> GetRoleById(Guid roleId)
        {
            var getRoleByIdHandler = new GetRoleByIdHandler(roleQueryService);
            return getRoleByIdHandler.HandleRequest(roleId);
        }

        public Task<RoleDto?> GetRoleByName(string roleName)
        {
            var getRoleByNameHandler = new GetRoleByNameHandler(roleQueryService);
            return getRoleByNameHandler.HandleRequest(roleName);
        }

        public Task<List<RoleDto>?> GetAllRoles()
        {
            var getAllRolesHandler = new GetAllRolesHandler(roleQueryService);
            return getAllRolesHandler.HandleRequest(null);
        }
    }
}