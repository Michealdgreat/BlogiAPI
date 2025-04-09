using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.Role;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.RoleService.CommandService; 

namespace BlogiAPI.Chain.Handlers.Role
{
    public class CreateRoleHandler(RoleCommandService roleCommandService) : Handler<ICommandBase>
    {
        private readonly RoleCommandService _roleCommandService = roleCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is CreateRoleCommand command)
                {
                    var result = await _roleCommandService.CreateRole(command);
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