﻿using Microsoft.EntityFrameworkCore;
using KieuGiaConstruction.Models;

namespace KieuGiaConstruction.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Ví dụ bảng Users
    }
}