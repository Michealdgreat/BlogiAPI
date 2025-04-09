using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.PostService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Post
{
    public class GetPostByIdHandler(PostQueryService postQueryService) : QueryHandler<PostDto, Guid>
    {
        private readonly PostQueryService _postQueryService = postQueryService;

        public override async Task<PostDto?> HandleRequest(Guid request)
        {
            var result = await _postQueryService.GetPostById(request);
            return result;
        }
    }
}