using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetLayeredArchitectureWithDapper.Business.Interfaces
{
    public interface IRepositoryManager<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Add(T entity);
        bool AddMultiple(IEnumerable<T> entity);
        bool Delete(int id);
        bool Update(T entity);
    }
}
