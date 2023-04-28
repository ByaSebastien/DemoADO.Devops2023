using DemoADO.BLL.Services;
using DemoADO.Models;

BookService bookService = new BookService();


//IEnumerable<Book> books = bookService.GetAll();

//foreach (Book book in books)
//{
//    Console.WriteLine(book);
//}

Book book = bookService.GetOne("9780143130154");
Console.WriteLine(book);
