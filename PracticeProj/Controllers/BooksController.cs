using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProj.BookDbContext;
using PracticeProj.Models;
using PracticeProj.Repository;

namespace PracticeProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        public BooksController(IBookRepo repo)
        {
            bookRepo = repo;

        }
        [HttpGet]
        [Route("GetBooks")]
        public IActionResult GetBooks()
        {
            if (bookRepo.GetAllBooks().Count()==0)
            {
                return NotFound("Book List not found");
            }
            var res = bookRepo.GetAllBooks();
            return Ok(res);
        }
        [HttpGet]
        public IActionResult GetBooksById(int id)
        {
            var res = bookRepo.GetBook(id);
            if(res==null)
            {
                return NotFound("Book Not found for this Id");

            }
            return Ok(res);

        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Books book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            var res = bookRepo.AddBook(book);
            return Ok(res);
        }

    }
}
