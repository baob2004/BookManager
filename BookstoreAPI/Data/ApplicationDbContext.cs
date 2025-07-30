using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Models;
using BookstoreAPI.Models.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Fiction",
                    Description = "Fictional literature and novels",
                    CreatedAt = new DateTime(2025, 7, 30, 21, 24, 0)
                },
                new Category
                {
                    Id = 2,
                    Name = "Non-Fiction",
                    Description = "Books based on real events and facts",
                    CreatedAt = new DateTime(2025, 7, 30, 21, 24, 0)
                },
                new Category
                {
                    Id = 3,
                    Name = "Science",
                    Description = "Books about scientific topics",
                    CreatedAt = new DateTime(2025, 7, 30, 21, 24, 0)
                }
            );


            List<IdentityRole> roles = new List<IdentityRole>()
                        {
                new IdentityRole
                {
                    Id = "8D04DCE2-969A-435D-BBA4-DF3F325983DC",  // Giá trị tĩnh cho Id (Guid.ToString())
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "8D04DCE2-969A-435D-BBA4-DF3F325983DC"  // Giá trị tĩnh, có thể dùng chung Guid
                },
                new IdentityRole
                {
                    Id = "69BD714F-9576-45BA-B5B7-F00649BE00DE",  // Giá trị tĩnh khác cho Id
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "69BD714F-9576-45BA-B5B7-F00649BE00DE"  // Giá trị tĩnh
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}