using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Books.Models;

namespace Books.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        IList<TEntity> GetWithCriteria(Expression<Func<TEntity, bool>> criteria);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
