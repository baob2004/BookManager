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

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

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

            // Seed data for Book with static CreatedAt and PublishDate
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "978-0451524935",
                    Price = 15.99m,
                    Stock = 50,
                    ImageUrl = "https://example.com/images/1984.jpg",
                    PublishDate = new DateTime(1949, 6, 8),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "978-0446310789",
                    Price = 12.50m,
                    Stock = 30,
                    ImageUrl = "https://example.com/images/tokillamockingbird.jpg",
                    PublishDate = new DateTime(1960, 7, 11),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    ISBN = "978-0062316097",
                    Price = 20.00m,
                    Stock = 25,
                    ImageUrl = "https://example.com/images/sapiens.jpg",
                    PublishDate = new DateTime(2014, 9, 9),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "A Brief History of Time",
                    Author = "Stephen Hawking",
                    ISBN = "978-0553380163",
                    Price = 18.75m,
                    Stock = 20,
                    ImageUrl = "https://example.com/images/briefhistory.jpg",
                    PublishDate = new DateTime(1988, 3, 1),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 3
                },
                new Book
                {
                    Id = 5,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    ISBN = "978-0141439518",
                    Price = 10.99m,
                    Stock = 40,
                    ImageUrl = "https://example.com/images/prideandprejudice.jpg",
                    PublishDate = new DateTime(1813, 1, 28),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 1
                },
                new Book
                {
                    Id = 6,
                    Title = "The Selfish Gene",
                    Author = "Richard Dawkins",
                    ISBN = "978-0199291151",
                    Price = 14.95m,
                    Stock = 15,
                    ImageUrl = "https://example.com/images/selfishgene.jpg",
                    PublishDate = new DateTime(1976, 11, 1),
                    CreatedAt = new DateTime(2025, 7, 30, 21, 58, 0),
                    CategoryId = 3
                }
            );

            // Configure one-to-many relationship
            builder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

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