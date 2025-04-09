using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogiAPI.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Address { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
