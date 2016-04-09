using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T>  FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void SoftDelete(T entity);
    }
}