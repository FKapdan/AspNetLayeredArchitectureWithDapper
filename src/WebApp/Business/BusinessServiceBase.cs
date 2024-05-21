using Core.Abstracts;
using Core.Entities.Abstracts;

namespace Business
{
    public abstract class BusinessServiceBase<T> : ILayerBase<T> where T : IEntity
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
