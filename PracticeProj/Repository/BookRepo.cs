using PracticeProj.BookDbContext;
using PracticeProj.Models;

namespace PracticeProj.Repository
{
    public class BookRepo:IBookRepo
    {
        private readonly BooksDbContext bookDb;
        public  BookRepo(BooksDbContext bookDbContext)
        {
            bookDb = bookDbContext;
        }
        public Books AddBook(Books books)
        {
            bookDb.books.Add(books);
            bookDb.SaveChanges();
            return books;
            
        }
        public List<Books> GetAllBooks()
        {
            
            return bookDb.books.ToList();
            
        }
        public Books GetBook(int id)
        {
            var book = bookDb.books.FirstOrDefault(x => x.Id == id);
           
            return  book;
        }
    }
}
