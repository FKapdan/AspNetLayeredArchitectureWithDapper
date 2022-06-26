using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Business
{
    public abstract class BusinessServiceBase<T> : IBusinessServiceBase<T> where T : class
    {
       public virtual IResultBase Add(T entity)
        {
            throw new NotImplementedException();
        }

       public virtual IResultBase AddMultiple(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

       public virtual IResultBase Delete(int id)
        {
            throw new NotImplementedException();
        }

       public virtual IDataResultBase<T> Get(T entity)
        {
            throw new NotImplementedException();
        }

       public virtual IDataResultBase<T> Get(int id)
        {
            throw new NotImplementedException();
        }

       public virtual IDataResultBase<IEnumerable<T>> GetList()
        {
            throw new NotImplementedException();
        }

       public virtual IResultBase Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
