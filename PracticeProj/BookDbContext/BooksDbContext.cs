using Microsoft.EntityFrameworkCore;
using PracticeProj.Models;

namespace PracticeProj.BookDbContext
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> dbContext) : base(dbContext)
        {
        }
        public DbSet<Books> books { get; set; } 
    }

}

