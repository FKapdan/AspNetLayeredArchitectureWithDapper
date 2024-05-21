using Core.Entities.Abstracts;

namespace Core.Abstracts
{
    public interface ILayerBase<TEntity> where TEntity : IEntity
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
