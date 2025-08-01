using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Models.Dtos.Book;
using BookstoreAPI.Models.Entitites;

namespace BookstoreAPI.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                Stock = book.Stock,
                ImageUrl = book.ImageUrl,
                PublishDate = book.PublishDate,
                CreatedAt = book.CreatedAt,
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name
            };
        }

        public static Book ToBookFromCreate(this CreateBookDto book, int CategoryId)
        {
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                Stock = book.Stock,
                ImageUrl = book.ImageUrl,
                PublishDate = book.PublishDate,
                CategoryId = CategoryId,
            };
        }

        public static Book ToBookFromUpdate(this UpdateBookDto book, int id)
        {
            return new Book
            {
                Id = id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                Stock = book.Stock,
                ImageUrl = book.ImageUrl,
                PublishDate = book.PublishDate,
                CategoryId = book.CategoryId
            };
        }
    }
}