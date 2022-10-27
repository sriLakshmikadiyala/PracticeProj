using PracticeProj.Models;

namespace PracticeProj.Repository
{
    public interface IBookRepo
    {
        Books AddBook(Books books);
        List<Books> GetAllBooks();
        Books GetBook(int id);
    }
}
