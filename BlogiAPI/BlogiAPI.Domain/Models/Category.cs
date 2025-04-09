namespace BlogiAPI.Domain.Models;

public class Category
{
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}