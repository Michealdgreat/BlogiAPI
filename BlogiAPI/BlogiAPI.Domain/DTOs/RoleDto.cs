namespace BlogiAPI.Domain.DTOs
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}