using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using BlogiAPI.Client.Orchestrators; 
using BlogiAPI.Controllers.Base; 
using BlogiAPI.Domain.Commands.Role;
using BlogiAPI.Domain.DTOs;

namespace BlogiAPI.Controllers
{
    [Authorize]
    public class RoleController(RoleOrchestrator roleOrchestrator) : ApiControllerBase
    {
        private readonly RoleOrchestrator _roleOrchestrator = roleOrchestrator;

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _roleOrchestrator.CreateRole(command);
            if (result.IsSuccess)
                return Ok(result); 
            return BadRequest(result);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _roleOrchestrator.UpdateRole(command);
            if (result.IsSuccess)
                return Ok(result); 
            return BadRequest(result); 
        }


        [HttpGet("GetRoleById/{roleId:guid}")]
        public async Task<IActionResult> GetRoleById(Guid roleId)
        {
            var result = await _roleOrchestrator.GetRoleById(roleId);
            if (result is null)
                return NotFound();
            return Ok(result); 
        }

        [HttpGet("GetRoleByName/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            var result = await _roleOrchestrator.GetRoleByName(roleName);
            if (result is null)
                return NotFound(); 
            return Ok(result); 
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleOrchestrator.GetAllRoles();
            return Ok(result); 
        }
    }
}