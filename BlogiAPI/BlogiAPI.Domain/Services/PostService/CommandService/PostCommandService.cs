using BlogiAPI.Domain.Commands.Post;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.PostService.CommandService
{
    public class PostCommandService(IPostRepository repository, IUserRepository userRepository)
    {
        private readonly IPostRepository _repository = repository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<OperationResult> CreatePost(CreatePostCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to create posts");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.Content) || 
                    string.IsNullOrWhiteSpace(command.ImageUrl) || command.CategoryId == Guid.Empty)
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (createQuery, parameters) = SqlCommandFactory.CreatePostCommand(
                    Guid.NewGuid(),
                    command.Title,
                    command.Content,
                    command.ImageUrl,
                    command.CategoryId,
                    command.CommandSender.UserId,
                    command.IsPublished
                );

                await _repository.SaveData(createQuery, parameters);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error creating post: {e.Message}");
            }
        }

        public async Task<OperationResult> UpdatePost(UpdatePostCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to update posts");
                }

                var (getPostQuery, getParams) = SqlQueryFactory.GetPostByIdQuery(command.PostId);
                var post = await _repository.LoadOneData<PostDto, object>(getPostQuery, getParams);

                if (post == null)
                {
                    return OperationResult.Error("Post does not exist");
                }

                if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.Content) || 
                    string.IsNullOrWhiteSpace(command.ImageUrl) || command.CategoryId == Guid.Empty)
                {
                    return OperationResult.Error("Please provide all valid parameters");
                }

                var (updateQuery, updateParams) = SqlCommandFactory.UpdatePostCommand(
                    command.PostId,
                    command.Title,
                    command.Content,
                    command.ImageUrl,
                    command.CategoryId,
                    command.IsPublished
                );

                await _repository.SaveData(updateQuery, updateParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error updating post: {e.Message}");
            }
        }

        public async Task<OperationResult> DeletePost(DeletePostCommand command)
        {
            try
            {
                if (command.CommandSender == null || command.CommandSender.Role != "Admin")
                {
                    return OperationResult.Error("You are not allowed to delete posts");
                }

                var (getPostQuery, getParams) = SqlQueryFactory.GetPostByIdQuery(command.PostId);
                var post = await _repository.LoadOneData<PostDto, object>(getPostQuery, getParams);

                if (post == null)
                {
                    return OperationResult.Error("Post does not exist");
                }

                var (deleteQuery, deleteParams) = SqlCommandFactory.DeletePostCommand(command.PostId);
                await _repository.DeleteData(deleteQuery, deleteParams);
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error($"Error deleting post: {e.Message}");
            }
        }
    }
}