using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories.Base;
using BlogiAPI.Domain.Repositories.SqlFactory;
using BlogiAPI.Domain.Services.Sha256Hash;

namespace BlogiAPI.Domain.Services.Auth;

public class AuthService(IBaseRepository repository, IConfiguration configuration)
{
    
    private readonly IBaseRepository _repository = repository;
    private readonly IConfiguration _configuration = configuration;
    
    public async Task<string> AuthenticateUser(UserLoginCommand request)
    {

        try
        {
            var handler = new JwtSecurityTokenHandler();
            ArgumentNullException.ThrowIfNull(request.Email, nameof(request.Email));
            ArgumentNullException.ThrowIfNull(request.Password, nameof(request.Password));

            var user = await FindUserByEmail(request.Email) ?? throw new AuthenticationException("User not found");
            var hashedPassword = Sha256Hasher.Hash(request.Password);

            if (user.PasswordHash != hashedPassword)
                throw new AuthenticationException("Password not correct");
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = GenerateClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = credentials,
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"],
            };

            var token = handler.CreateToken(tokenDescriptor);
            var writeToken = handler.WriteToken(token);

            return writeToken;
            
        }
        catch (Exception)
        {

            return null;
        }
        
    }

    private  async Task<UserWithRoleDto?> FindUserByEmail(string email)
    {
        try
        {
            var (emailQuery, emailParameter) = SqlQueryFactory.GetUserByEmailWithRoleQuery(email);
            return await _repository.LoadOneData<UserWithRoleDto, dynamic>(emailQuery, emailParameter);
        }
        catch (Exception ex)
        {
            return null;
        }
            
    }
    
    private static ClaimsIdentity GenerateClaims(UserWithRoleDto user)
    {
        var claims = new List<Claim>
        {
            
            new ("UserId", user.UserId.ToString()),
            new ("FirstName", user.Firstname!),
            new ("LastName", user.Lastname!),
            new ("Role", user.RoleName!),
            new (ClaimTypes.Email, user.Email!),
            new ("jwtid", Guid.NewGuid().ToString()),

        };

        return new ClaimsIdentity(claims);
    }

}