using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    { 
        T Add(T entity);

        T Get(int id);

        List<T> GetAll();

        T Update(T entity);

        void Delete(int id);
    }
}
