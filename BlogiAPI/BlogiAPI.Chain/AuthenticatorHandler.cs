using BlogiAPI.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogiAPI.Chain;
using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;

namespace BlogiAPI.Chain
{
    public class AuthenticatorHandler(AuthService authService) : Handler<ICommandBase>
    {
        private readonly AuthService _authService = authService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {

            return OperationResult.Error("Not implemented");
        }
    }
}
