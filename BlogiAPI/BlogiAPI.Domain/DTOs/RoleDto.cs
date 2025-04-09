namespace BlogiAPI.Domain.DTOs
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}