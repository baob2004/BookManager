using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreAPI.Models.Dtos.Book
{
    public class UpdateBookDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Author cannot be over 100 characters")]
        public string Author { get; set; } = string.Empty;
        [MaxLength(13, ErrorMessage = "ISBN cannot be over 100 characters")]
        public string? ISBN { get; set; }
        [Required]
        [Range(0.001, 10000, ErrorMessage = "Price can only be between 0.001 and 10000")]
        public Decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be below 0")]
        public int Stock { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}