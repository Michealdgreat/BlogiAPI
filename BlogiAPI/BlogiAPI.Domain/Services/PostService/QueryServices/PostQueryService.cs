using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.PostService.QueryServices;

public class PostQueryService(IPostRepository repository)
{
    private readonly IPostRepository _repository = repository;

    public async Task<PostDto?> GetPostById(Guid postId)
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetPostByIdQuery(postId);
            var post = await _repository.LoadOneData<PostDto, object>(getQuery, getParams);
            return post;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<PostDto>?> GetAllPosts()
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetAllPostsQuery();
            var posts = await _repository.LoadData<PostDto, object>(getQuery, getParams);
            return posts;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<PostDto>?> GetPostsByCategoryId(Guid categoryId)
    {
        try
        {
            var (getQuery, getParams) = SqlQueryFactory.GetPostsByCategoryIdQuery(categoryId);
            var posts = await _repository.LoadData<PostDto, object>(getQuery, getParams);
            return posts;
        }
        catch (Exception)
        {
            return null;
        }
    }
}