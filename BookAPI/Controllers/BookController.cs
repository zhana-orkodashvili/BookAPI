using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Models;


namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookByID(string id)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook == null)
                return BadRequest("Invalid ID! Book not found.");
            return Ok(dbBook);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
        {
            var dbBook = await _context.Books.FindAsync(request.BookId);
            if (dbBook == null)
                return BadRequest("Invalid ID! Book not found to update.");

            dbBook.BookId = request.BookId;
            dbBook.Title = request.Title;
            dbBook.Author = request.Author;
            dbBook.PublicationDate = request.PublicationDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> RemoveBook(string id)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook == null)
                return BadRequest("Invalid ID! Book not found.");

            _context.Books.Remove(dbBook);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }
    }
}
