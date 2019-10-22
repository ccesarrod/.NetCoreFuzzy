using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fuzzy.core.DataCore.Contracts
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> expresion);
        void Delete(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Save();
     



    }
}
