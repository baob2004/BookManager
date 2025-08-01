using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Models.Dtos.Category;
using BookstoreAPI.Models.Entitites;

namespace BookstoreAPI.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Books = category.Books.Select(b => b.ToBookDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreate(this CreateCategoryDto category)
        {
            return new Category
            {
                Name = category.Name,
                Description = category.Description,
            };
        }
    }
}