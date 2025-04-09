namespace BlogiAPI.Domain.Models;

public class Post
{
    public Guid PostId { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; } = false;
}