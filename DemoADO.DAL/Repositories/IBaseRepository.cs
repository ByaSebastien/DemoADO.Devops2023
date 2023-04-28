using DemoADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.DAL.Repositories
{
    public interface IBaseRepository<TKey,TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(TKey id);
        bool Insert(TEntity entity);
        bool Update(TKey id, TEntity entity);
        bool Delete(TKey id);
    }
}
