using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAPI.Data;
using BookstoreAPI.Mappers;
using BookstoreAPI.Models.Dtos.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Controllers
{
    [Route("/api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Books.Include(b => b.Category).Select(b => b.ToBookDto()).ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingBook = await _context.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);

            if (existingBook == null)
            {
                return NotFound("Book Not Found");
            }

            return Ok(existingBook.ToBookDto());
        }

        [HttpPost("{CategoryId}")]
        public async Task<IActionResult> Create([FromRoute] int CategoryId, [FromBody] CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookModel = createBookDto.ToBookFromCreate(CategoryId);

            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();

            // Reload the book with the Category navigation property included
            var savedBook = await _context.Books
                .Include(b => b.Category)  // Eagerly load the Category
                .FirstOrDefaultAsync(b => b.Id == bookModel.Id);

            if (savedBook == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = bookModel.Id }, savedBook.ToBookDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updateBookDto.CategoryId);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            book.Title = updateBookDto.Title;
            book.Author = updateBookDto.Author;
            book.ISBN = updateBookDto.ISBN;
            book.Price = updateBookDto.Price;
            book.Stock = updateBookDto.Stock;
            book.ImageUrl = updateBookDto.ImageUrl;
            book.PublishDate = updateBookDto.PublishDate;
            book.CategoryId = updateBookDto.CategoryId;

            await _context.SaveChangesAsync();

            var savedBook = await _context.Books
           .Include(b => b.Category)
           .FirstOrDefaultAsync(b => b.Id == id);

            if (savedBook == null)
            {
                return NotFound();  // Unlikely, but for safety
            }

            return Ok(savedBook.ToBookDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}