using System;

namespace BlogiAPI.Domain.DTOs
{
    public class BannerAdDto
    {
        public Guid BannerId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}