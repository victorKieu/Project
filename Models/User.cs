using System;

namespace KieuGiaConstruction.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; } 
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; internal set; }
    }
}