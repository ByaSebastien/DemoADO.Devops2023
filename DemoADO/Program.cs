using DemoADO.BLL.Services;
using DemoADO.Models;

BookService bookService = new BookService();


IEnumerable<Book> books = bookService.GetAll();

foreach (Book book in books)
{
    Console.WriteLine(book);
}
