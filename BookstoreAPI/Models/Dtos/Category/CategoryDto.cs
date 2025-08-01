using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Models.Dtos.Book;
using BookstoreAPI.Models.Entitites;

namespace BookstoreAPI.Models.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}