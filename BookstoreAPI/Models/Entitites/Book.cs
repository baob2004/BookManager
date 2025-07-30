using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreAPI.Models.Entitites
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        // Navigation Property
        public required Category Category { get; set; }
    }
}