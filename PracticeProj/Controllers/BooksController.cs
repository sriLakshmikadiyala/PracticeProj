using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// Returns List of all Books 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBooks")]
        public IActionResult GetBooks()
        {
            var res = bookRepo.GetAllBooks();
            return res.Count() == 0 ? NotFound("Book List not found") : Ok(res);
        }
        /// <summary>
        /// Return Book by Input Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBooksById(int id)
        {
            var res = bookRepo.GetBook(id);
            return res == null ? NotFound("Book Not found for this Id") : Ok(res);
        }
        /// <summary>
        /// Returns Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] Books book)
        {
            return book == null ? BadRequest() : Ok(bookRepo.AddBook(book));
        }
        /// <summary>
        /// Update Book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Books book)
        {
            return book==null? BadRequest():Ok(bookRepo.UpdateBook(book));
        }
    }
}
