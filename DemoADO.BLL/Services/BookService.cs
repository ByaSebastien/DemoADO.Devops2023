using DemoADO.DAL.Repositories;
using DemoADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.BLL.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetOne(string isbn)
        {
            return _bookRepository.GetOne(isbn);
        }

        public bool Insert(Book book)
        {
            return _bookRepository.Insert(book);
        }
    }
}
