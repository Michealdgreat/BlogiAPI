namespace BlogiAPI.Domain.Models;

public class CarouselBanner
{
    public Guid CarouselId { get; set; } = Guid.NewGuid();
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
    public string? RedirectUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}