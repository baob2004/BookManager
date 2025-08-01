using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Models.Entitites;

namespace BookstoreAPI.Models.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}