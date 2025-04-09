using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services.PostService.QueryServices;

namespace BlogiAPI.Chain.Handlers.Post
{
    public class GetPostsByCategoryIdHandler(PostQueryService postQueryService) : QueryHandler<List<PostDto>, Guid>
    {
        private readonly PostQueryService _postQueryService = postQueryService;

        public override async Task<List<PostDto>?> HandleRequest(Guid request)
        {
            var result = await _postQueryService.GetPostsByCategoryId(request);
            return result;
        }
    }
}