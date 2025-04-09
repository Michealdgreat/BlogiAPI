using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Controllers.Base;
using BlogiAPI.Domain.Commands.Category;
using BlogiAPI.Domain.DTOs;

namespace BlogiAPI.Controllers
{
    [Authorize]
    public class CategoryController(CategoryOrchestrator categoryOrchestrator) : ApiControllerBase
    {
        private readonly CategoryOrchestrator _categoryOrchestrator = categoryOrchestrator;

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _categoryOrchestrator.CreateCategory(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _categoryOrchestrator.UpdateCategory(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _categoryOrchestrator.DeleteCategory(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryOrchestrator.GetAllCategories();
            return Ok(result);
        }
    }
}