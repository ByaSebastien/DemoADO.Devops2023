using DemoADO.BLL.Services;
using DemoADO.Models;

BookService bookService = new BookService();


//IEnumerable<Book> books = bookService.GetAll();

//foreach (Book book in books)
//{
//    Console.WriteLine(book);
//}
//try
//{
//    Book book = bookService.GetOne("dfdh");
//    Console.WriteLine(book);
//}
//catch (KeyNotFoundException)
//{
//    Console.WriteLine("Tu cherches quoi fieu?");
//}
Book book = new Book()
{
    Isbn = "9780981162614",
    Title = "L'Art de la guerre",
    Author = "Sun Tzu",
    Description = "L''Art de la guerre est un traité de stratégie militaire écrit par le général chinois Sun Tzu au Ve siècle av. J.-C. Il est considéré comme un classique de la stratégie et de la philosophie.",
    Category = "Stratégie"
};
Console.WriteLine(bookService.Insert(book));
