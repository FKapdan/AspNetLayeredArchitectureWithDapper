using Core.Entities.Abstracts;
using Entities.Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity :  IEntity
    {
        IDataResultBase<IEnumerable<TEntity>> GetList();
        IDataResultBase<TEntity> Get(TEntity entity);
        IDataResultBase<TEntity> Get(int id);
        IResultBase Add(TEntity entity);
        IResultBase AddMultiple(IEnumerable<TEntity> entity);
        IResultBase Delete(int id);
        IResultBase Update(TEntity entity);
    }
}
