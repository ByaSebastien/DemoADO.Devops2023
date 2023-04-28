using DemoADO.Models;

namespace DemoADO.DAL.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
    }
}