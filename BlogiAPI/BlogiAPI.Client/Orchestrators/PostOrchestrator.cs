using BlogiAPI.Chain;
using BlogiAPI.Chain.Handlers.Post;
using BlogiAPI.Domain.Commands.Post;
using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Services;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.PostService.CommandService;
using BlogiAPI.Domain.Services.PostService.QueryServices;

namespace BlogiAPI.Client.Orchestrators;

public class PostOrchestrator(PostCommandService postCommandService, PostQueryService postQueryService, AuthService authService)
{
    private readonly AuthService _authService = authService;
    private readonly PostCommandService _postCommandService = postCommandService;
    private readonly PostQueryService _postQueryService = postQueryService;

    public Task<OperationResult> CreatePost(CreatePostCommand command)
    {
        var createPostHandler = new CreatePostHandler(_postCommandService);
        return createPostHandler.HandleRequest(command);
    }

    public Task<OperationResult> UpdatePost(UpdatePostCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var updatePostHandler = new UpdatePostHandler(_postCommandService);
        authorizationHandler.SetNext(updatePostHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<OperationResult> DeletePost(DeletePostCommand command)
    {
        var authorizationHandler = new AuthorizationHandler(_authService);
        var deletePostHandler = new DeletePostHandler(_postCommandService);
        authorizationHandler.SetNext(deletePostHandler);
        return authorizationHandler.HandleRequest(command);
    }

    public Task<PostDto?> GetPostById(Guid postId)
    {
        var getPostByIdHandler = new GetPostByIdHandler(_postQueryService);
        return getPostByIdHandler.HandleRequest(postId);
    }

    public Task<List<PostDto>?> GetAllPosts()
    {
        var getAllPostsHandler = new GetAllPostsHandler(_postQueryService);
        return getAllPostsHandler.HandleRequest(null);
    }

    public Task<List<PostDto>?> GetPostsByCategoryId(Guid categoryId)
    {
        var getPostsByCategoryIdHandler = new GetPostsByCategoryIdHandler(_postQueryService);
        return getPostsByCategoryIdHandler.HandleRequest(categoryId);
    }
}