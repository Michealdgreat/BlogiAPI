using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.UserServices.CommandServices;

namespace BlogiAPI.Chain.Handlers.User
{
    public class CreateUserHandler(UserCommandServices userCommandService) : Handler<ICommandBase>
    {
        private readonly UserCommandServices _userCommandService = userCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is CreateUserCommand command)
                {
                    var result = await _userCommandService.CreateUser(command);
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