﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogiAPI.Domain.Models
{
    public class Role
    {
        public Guid RoleId { get; set; } 
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
