using Core.Entities.Abstracts;

namespace Core.Abstracts
{
    public abstract class LayerAbstractBase<TEntity> : ILayerBase<TEntity> where TEntity : IEntity
    {
        public virtual IResultBase Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResultBase> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase AddMultiple(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResultBase> AddMultipleAsync(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResultBase> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IDataResultBase<TEntity> Get(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IDataResultBase<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IDataResultBase<TEntity>> GetAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IDataResultBase<TEntity>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IDataResultBase<IEnumerable<TEntity>> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IDataResultBase<IEnumerable<TEntity>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResultBase> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
