using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.Post;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.PostService.CommandService;

namespace BlogiAPI.Chain.Handlers.Post
{
    public class CreatePostHandler(PostCommandService postCommandService) : Handler<ICommandBase>
    {
        private readonly PostCommandService _postCommandService = postCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is CreatePostCommand command)
                {
                    var result = await _postCommandService.CreatePost(command);
                    return result;
                }
            }
            catch (Exception)
            {
                return OperationResult.Error("Operation failed");
            }

            return OperationResult.Error("Operation failed");
        }
    }
}