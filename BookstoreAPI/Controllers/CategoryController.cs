using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Data;
using BookstoreAPI.Mappers;
using BookstoreAPI.Models.Dtos.Category;
using BookstoreAPI.Models.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookstoreAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.Include(c => c.Books).Select(c => c.ToCategoryDto()).ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Category? existingCategory = await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
            return existingCategory == null ? NotFound() : Ok(existingCategory.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = createCategoryDto.ToCategoryFromCreate();
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCategory = await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category Not Found");
            }

            existingCategory.Name = updateCategoryDto.Name;
            existingCategory.Description = updateCategoryDto.Description;

            await _context.SaveChangesAsync();

            return Ok(existingCategory.ToCategoryDto());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingCategory = await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category Not Found");
            }

            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}