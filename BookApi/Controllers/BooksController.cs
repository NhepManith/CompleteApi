
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>() {

        new Book()
        
        };


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return _books;
        }

        [HttpGet("{id}")]

        public ActionResult<Book> GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();

            }

            return book;

        }

        [HttpPost]

        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);

            return CreatedAtAction(nameof(GetBookById), new {id=book.Id} , book);

        }

        [HttpPut("{id}")]

        public ActionResult <Book> UpdateBook (int id, Book UpdateBook)
        {
            var book = _books.FirstOrDefault(b =>b.Id == id);
            if (book == null)
                return NotFound();

            book.Title = UpdateBook.Title;
            book.Author = UpdateBook.Author;
            book.Year = UpdateBook.Year;

            return NoContent();
        }

        [HttpDelete ("{id}")]

        public ActionResult<Book> DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(a => a.Id == id);
            
            if(book == null)
                return NotFound();

            _books.Remove(book);

            return book;
                
        }

    }
}
