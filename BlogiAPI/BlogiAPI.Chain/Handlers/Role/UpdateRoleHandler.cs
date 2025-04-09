using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.Role;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.RoleService.CommandService; 

namespace BlogiAPI.Chain.Handlers.Role
{
    public class UpdateRoleHandler(RoleCommandService roleCommandService) : Handler<ICommandBase>
    {
        private readonly RoleCommandService _roleCommandService = roleCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is UpdateRoleCommand command)
                {
                    var result = await _roleCommandService.UpdateRole(command);
                    return result;
                }
            }
            catch (Exception)
            {
                return OperationResult.Error("Operation failed");
            }

            return OperationResult.Error("Operation failed");
        }
    }
}