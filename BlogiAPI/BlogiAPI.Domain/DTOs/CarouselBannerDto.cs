using System;

namespace BlogiAPI.Domain.DTOs
{
    public class CarouselBannerDto
    {
        public Guid CarouselId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
        public string? RedirectUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}