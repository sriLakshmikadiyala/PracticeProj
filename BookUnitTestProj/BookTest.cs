using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Moq;
using PracticeProj.BookDbContext;
using PracticeProj.Controllers;
using PracticeProj.Models;
using PracticeProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookUnitTestProj
{

    public class BookTest
    {
        private readonly Mock<IBookRepo> _bookRepoMock;
        public BookTest()
        {
            _bookRepoMock = new Mock<IBookRepo>();
        }
        [Fact]
        public void GetAllBooksShouldReturnOk()
        {
            //Arrange
            var list=GetBooksData();
            _bookRepoMock.Setup(x=>x.GetAllBooks()).Returns(list);
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.GetBooks();
            var lists = res as OkObjectResult;
            var actual = lists?.Value as IEnumerable<Books>;
            //Assert
            Assert.IsType<OkObjectResult>(lists);
            Assert.Equal(list, actual);
  
        }
        [Fact]
        public void GetAllBooksReturnNotFound()
        {
            var list = new List<Books > ();
            _bookRepoMock.Setup(x => x.GetAllBooks()).Returns(list);
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.GetBooks();    
            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
            
        }

        [Fact]
        public void AddBookReturnOk()
        {
            var book = new Books()
            {
                Id = 1,
                Name = "Sree",
                AuthorName = "James"
            };           
            _bookRepoMock.Setup(x => x.AddBook(book)).Returns(book);
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.AddBook(book);            
            //Assert
            Assert.IsType<OkObjectResult>(res);
            var item=res as OkObjectResult;
            Assert.IsType<Books>(item?.Value);
            var books = item?.Value as Books;
            Assert.Equal(book.Name, books?.Name);
            Assert.Equal(book.Id, books?.Id);
            Assert.Equal(book.AuthorName, books?.AuthorName);
        }
        [Fact]
        public void AddBookShouldReturnBadRequest()
        {
            //Arrange
            var book = new Books();
            book = null;
            _bookRepoMock.Setup(x => x.AddBook(book));
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.AddBook(book);
            //Assert
            Assert.IsType<BadRequestResult>(res);        
        }
        [Fact]
        public void GetBooksByIdReturnOk()
        {
            //Arrange
            var list = GetBooksData();
            int id = 1;
            _bookRepoMock.Setup(x => x.GetBook(id)).Returns(list[0]);
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.GetBooksById(id);
            var lists = res as OkObjectResult;
            //Assert
            Assert.IsType<OkObjectResult>(lists);
            Assert.Equal(id, list[0].Id);
            Assert.Equal(lists, res);
        }
        [Fact]
        public void GetBookByIdShouldReturnNotFound()
        {
            //Arrange
            var list = GetBooksData();
            int id = 2;
            _bookRepoMock.Setup(x => x.GetBook(id));
            var controller = new BooksController(_bookRepoMock.Object);
            //Act
            var res = controller.GetBooksById(id);
            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
        }

        private List<Books> GetBooksData()
        {
            List<Books> books = new List<Books>
            {
                new Books
                {
                    Id = 1,
                    Name="The Nature",
                    AuthorName="Sree"
                }
            };
            return books;
        }
    }
}
