using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Controllers.Base;
using BlogiAPI.Domain.Commands.User;
using BlogiAPI.Domain.DTOs; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BlogiAPI.Domain.Services.Auth;

namespace BlogiAPI.Controllers
{
    
    public class UserController(UserOrchestrator userOrchestrator, AuthService authService) : ApiControllerBase
    {
        private readonly UserOrchestrator _userOrchestrator = userOrchestrator;
        private readonly AuthService _authService = authService;

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            var result = await _authService.AuthenticateUser(command);
            return Ok(result); 
        }
        
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _userOrchestrator.CreateUser(command);
            return Ok(result); 
        }
 
        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _userOrchestrator.UpdateUser(command);
            return Ok(result); 
        }

        [Authorize]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _userOrchestrator.DeleteUser(command);
            return Ok(result); 
        }

        [Authorize]
        [HttpGet("GetUserById/{userId:guid}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _userOrchestrator.GetUserById(userId);
            if (result is null)
                return NotFound(); 
            return Ok(result); 
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userOrchestrator.GetAllUsers();
            return Ok(result); 
        }

        [Authorize]
        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userOrchestrator.GetUserByEmail(email);
            if (result is null)
                return NotFound();
            return Ok(result); 
        }
    }
}