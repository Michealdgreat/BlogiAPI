using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Domain.Services.TokenService;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Controllers.Base;
[Route("api/[controller]")]
[ApiController]
public class ApiControllerBase : ControllerBase
{
    protected UserInfo? UserInformation =>
        (User.Identity as ClaimsIdentity)?.GetUserInfo();
}
