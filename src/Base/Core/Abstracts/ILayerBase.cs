using Core.Entities.Abstracts;

namespace Core.Abstracts
{
    public interface ILayerBase<TEntity> where TEntity : IEntity
    {
        IDataResultBase<IEnumerable<TEntity>> GetList();
        Task<IDataResultBase<IEnumerable<TEntity>>> GetListAsync();
        IDataResultBase<TEntity> Get(TEntity entity);
        Task<IDataResultBase<TEntity>> GetAsync(TEntity entity);
        IDataResultBase<TEntity> Get(int id);
        Task<IDataResultBase<TEntity>> GetAsync(int id);
        IResultBase Add(TEntity entity);
        Task<IResultBase> AddAsync(TEntity entity);
        IResultBase AddMultiple(IEnumerable<TEntity> entity);
        Task<IResultBase> AddMultipleAsync(IEnumerable<TEntity> entity);
        IResultBase Delete(int id);
        Task<IResultBase> DeleteAsync(int id);
        IResultBase Update(TEntity entity);
        Task<IResultBase> UpdateAsync(TEntity entity);
    }
}
