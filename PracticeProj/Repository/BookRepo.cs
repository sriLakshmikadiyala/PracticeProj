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
            try
            {
                bookDb.books.Add(books);
                bookDb.SaveChanges();
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Books> GetAllBooks()
        {
            try
            {
                return bookDb.books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Books GetBook(int id)
        {
            try
            {
                var book = bookDb.books.FirstOrDefault(x => x.Id == id);
                return book;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Books UpdateBook(Books books)
        {
            try
            {
                var book = bookDb.books.FirstOrDefault(x => x.Id== books.Id);
                book.Name=books.Name
                book.AuthorName = books.AuthorName;
                bookDb.books.Update(book);
                bookDb.SaveChanges();
                return bookDb.books.FirstOrDefault(x => x.Id == books.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
