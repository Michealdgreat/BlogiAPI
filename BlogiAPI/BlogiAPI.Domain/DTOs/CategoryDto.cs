using System;

namespace BlogiAPI.Domain.DTOs
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}