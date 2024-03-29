﻿using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities.Repository.Interfaces;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public virtual IResultBase Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase AddMultiple(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase Delete(int id)
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

        public virtual IDataResultBase<IEnumerable<TEntity>> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual IResultBase Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
