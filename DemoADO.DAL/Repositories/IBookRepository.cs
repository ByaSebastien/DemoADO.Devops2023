using DemoADO.Models;

namespace DemoADO.DAL.Repositories
{
    public interface IBookRepository : IBaseRepository<string,Book>
    {
    }
}