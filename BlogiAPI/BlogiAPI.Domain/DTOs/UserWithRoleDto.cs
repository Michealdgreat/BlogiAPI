namespace BlogiAPI.Domain.DTOs;

public class UserWithRoleDto
{
    public Guid UserId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? Address { get; set; }
    public Guid RoleId { get; set; }
    public string? RoleName { get; set; }  
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}