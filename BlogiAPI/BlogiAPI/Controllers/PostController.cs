using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Controllers.Base;
using BlogiAPI.Domain.Commands.Post;

namespace BlogiAPI.Controllers
{
    [Authorize]
    public class PostController(PostOrchestrator postOrchestrator) : ApiControllerBase
    {
        private readonly PostOrchestrator _postOrchestrator = postOrchestrator;

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(CreatePostCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _postOrchestrator.CreatePost(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost(UpdatePostCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _postOrchestrator.UpdatePost(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(DeletePostCommand command)
        {
            command.CommandSender = UserInformation;
            var result = await _postOrchestrator.DeletePost(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetPostById/{postId:guid}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var result = await _postOrchestrator.GetPostById(postId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _postOrchestrator.GetAllPosts();
            return Ok(result);
        }

        [HttpGet("GetPostsByCategoryId/{categoryId:guid}")]
        public async Task<IActionResult> GetPostsByCategoryId(Guid categoryId)
        {
            var result = await _postOrchestrator.GetPostsByCategoryId(categoryId);
            return Ok(result);
        }
    }
}