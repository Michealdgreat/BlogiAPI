using BlogiAPI.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;


namespace BlogiAPI.Chain
{
    public class AuthorizationHandler(AuthService authService) : Handler<ICommandBase>
    {
        private readonly AuthService _authService = authService;
        

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            
            try
            {
                
                if (request.CommandSender == null) return OperationResult.Error("Not Authorized");
                
                if (NextHandler != null)
                {
                    return await NextHandler.HandleRequest(request);
                }

                return OperationResult.Error("Authorization failed.");
            }
            catch (Exception)
            {
               return OperationResult.Error("Authorization failed.");
            }
        }
    }
}
