using System;

namespace BlogiAPI.Domain.DTOs
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPublished { get; set; }
    }
}