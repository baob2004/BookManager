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
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN,
                Price = bookModel.Price,
                Stock = bookModel.Stock,
                ImageUrl = bookModel.ImageUrl,
                PublishDate = bookModel.PublishDate,
                CreatedAt = bookModel.CreatedAt,
                CategoryId = bookModel.CategoryId,
                CategoryName = bookModel.Category.Name
            };
        }
    }
}