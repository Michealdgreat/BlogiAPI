using BlogiAPI.Chain.Base;
using BlogiAPI.Domain.Commands.Base;
using BlogiAPI.Domain.Commands.Post;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.PostService.CommandService;

namespace BlogiAPI.Chain.Handlers.Post
{
    public class UpdatePostHandler(PostCommandService postCommandService) : Handler<ICommandBase>
    {
        private readonly PostCommandService _postCommandService = postCommandService;

        public override async Task<OperationResult> HandleRequest(ICommandBase request)
        {
            try
            {
                if (request is UpdatePostCommand command)
                {
                    var result = await _postCommandService.UpdatePost(command);
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