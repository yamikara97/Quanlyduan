using System;
using System.Collections.Generic;
using System.Text;
using HD_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HD_proj.Data
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Phongban> Phongbans { get; set; }
        
        public DbSet<HD_proj.Models.Duan> Duan { get; set; }

        public DbSet<Chitietduan> Chitietduan { get; set; }

        public DbSet<Phancong> Phancong { get; set; }

        public DbSet<DanhmucFile> DanhmucFiles { get; set; }
    }
}
