using BlogiAPI.Domain.Commands.Role;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;


namespace BlogiAPI.Domain.Services.RoleService.CommandService
{
    public class RoleCommandService(IRoleRepository repository)
    {
        public async Task<OperationResult> CreateRole(CreateRoleCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to do this");
                }

                if (command.Name == null)
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }
                
                var (createQuery, parameters) = SqlCommandFactory.CreateRoleCommand(
                    Guid.NewGuid(),
                    command.Name
                );

                await repository.SaveData(createQuery, parameters);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error("Something went wrong");
            }
        }

        public async Task<OperationResult> UpdateRole(UpdateRoleCommand command)
        {
            try
            {
                var (getRoleQuery, parameters) = SqlQueryFactory.GetRoleByIdQuery(command.RoleId);
                var role = await repository.LoadOneData<RoleDto, object>(getRoleQuery, parameters);

                if (role == null)
                {
                    return OperationResult.Error("Role does not exist");
                }

                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to do this");
                }
                
                if (command.Name == null)
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (updateQuery, updateParameters) = SqlCommandFactory.UpdateRoleCommand(
                    command.RoleId,
                    command.Name
                );

                await repository.SaveData(updateQuery, updateParameters);
                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error("Something went wrong");
            }
        }

    }
}