﻿using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IDataResultBase<IEnumerable<T>> GetList();
        IDataResultBase<T> Get(int id);
        IResultBase Add(T entity);
        IResultBase AddMultiple(IEnumerable<T> entity);
        IResultBase Delete(int id);
        IResultBase Update(T entity);
    }
}
