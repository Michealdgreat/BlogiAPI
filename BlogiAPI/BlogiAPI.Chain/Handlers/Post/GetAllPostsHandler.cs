using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.PostService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Post
{
    public class GetAllPostsHandler(PostQueryService postQueryService) : QueryHandler<List<PostDto>, object>
    {
        private readonly PostQueryService _postQueryService = postQueryService;

        public override async Task<List<PostDto>?> HandleRequest(object? request)
        {
            var result = await _postQueryService.GetAllPosts();
            return result;
        }
    }
}