using System.Security.Claims;
using BlogiAPI.Domain.User;

namespace BlogiAPI.Domain.Services.TokenService;

public static class TokenExtension
{
        public static UserInfo? GetUserInfo(this ClaimsIdentity claimsIdentity)
        {

            try
            {

                var emailClaim = claimsIdentity.FindFirst(ClaimTypes.Email);
                var idClaim = claimsIdentity.FindFirst("UserId");
                var userRoleClaim = claimsIdentity.FindFirst("Role");
                var firstNameClaim = claimsIdentity.FindFirst("FirstName");
                var lastNameClaim = claimsIdentity.FindFirst("LastName");
                var jwt = claimsIdentity.FindFirst("jwtid");
                

                if (emailClaim == null || idClaim == null || firstNameClaim == null || lastNameClaim == null || jwt == null || userRoleClaim == null)
                {
                    throw new Exception("Required claim is missing");
                }
                
                var userInfo = new UserInfo()
                {
                    UserId = Guid.Parse(idClaim.Value),
                    Email = emailClaim.Value,
                    FirstName = firstNameClaim.Value,
                    LastName = lastNameClaim.Value,
                    Role = userRoleClaim.Value,
                };

                return userInfo;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
}