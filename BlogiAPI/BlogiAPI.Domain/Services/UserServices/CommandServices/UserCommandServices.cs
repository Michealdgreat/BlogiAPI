using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;
using BlogiAPI.Domain.Services.Sha256Hash;

namespace BlogiAPI.Domain.Services.UserServices.CommandServices;

public class UserCommandServices(IUserRepository userRepository, IRoleRepository roleRepository)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {

        try
        {
            /*if (command.CommandSender == null)
            {
                return OperationResult.Error("You are not logged in or authorized");
            }*/
            
            var (roleQuery, rolePara) = SqlQueryFactory.GetRoleByNameQuery("Admin");

            var role = await _roleRepository.LoadOneData<RoleDto, object>(roleQuery, rolePara);

            if (command.Address == null || command.Firstname == null || command.Email == null ||
                command.Lastname == null || command.Password == null || role == null)
            {
                return OperationResult.Error("Please provide a valid inputs");
            }
            
            var passwordHash = Sha256Hasher.Hash(command.Password);


            var (sqlQuery, parameter) = SqlCommandFactory.CreateUserCommand(Guid.NewGuid(), command.Firstname,
                command.Lastname, command.Email, passwordHash, command.Address, role.RoleId);

            await _userRepository.SaveData(sqlQuery, parameter);
            
            return OperationResult.Success();
            
        }
        catch (Exception e)
        {
            return OperationResult.Error(e.Message);
            
        }
    
    }


    public async Task<OperationResult> UpdateUser(UpdateUserCommand command)
    {
        try
        {

            if (string.IsNullOrWhiteSpace(command.Firstname) || string.IsNullOrWhiteSpace(command.Lastname) || string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Address) || command.CommandSender==null)
            {
                return OperationResult.Error("Please provide a valid inputs");
            }
            
            var (userQuery, userPara) = SqlQueryFactory.GetUserByIdQuery(command.CommandSender.UserId);
            var user = await _userRepository.LoadOneData<UserDto, object>(userQuery, userPara);

            if (user == null)
            {
                return OperationResult.Error("User not found");
            }
            
            var (updateQuery, paras) = SqlCommandFactory.UpdateUserCommand(command.UserId, command.Firstname, command.Lastname, command.Email, command.Address);
            
            await _userRepository.SaveData(updateQuery, paras);
            
            return OperationResult.Success();
        }
        catch (Exception e)
        {
          return OperationResult.Error(e.Message);
        }
    }
    
    public async Task<OperationResult> DeleteUser(DeleteUserCommand command)
    {
        try
        {
            var (userQuery, userPara) = SqlQueryFactory.GetUserByIdQuery(command.UserId);
            
            var user = await _userRepository.LoadOneData<UserDto, dynamic>(userQuery, userPara);

            if (user == null || command.CommandSender == null)
            {
                return OperationResult.Error("User not found");
            }

            if (user.UserId != command.CommandSender.UserId)
            {
                return OperationResult.Error("You are not authorized to delete this user");
            }
            
            
           
            var (deleteUser, deleteParameter) = SqlCommandFactory.DeleteUserCommand(command.UserId);
            
            await _userRepository.DeleteData(deleteUser, deleteParameter);
            
        }
        catch (Exception e)
        {
            return OperationResult.Error(e.Message);
        }
        
        return OperationResult.Success();
    }

   
}