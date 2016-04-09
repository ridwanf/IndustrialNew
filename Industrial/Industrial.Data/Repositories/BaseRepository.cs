using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core;

namespace Industrial.Data.Repositories
{
    /// <summary>
    ///     Serves as a generic base class for concrete repositories to supportz basic CRUD oprations on data in the system.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository works with. Must be a class inheriting DomainEntity.</typeparam>
    /// <typeparam name="TU"></typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable
        where T : class
    {
        /// <summary>
        ///     Disposes the underlying data context.
        /// </summary>
        public void Dispose()
        {
            if (DataContextFactory.GetDataContext() != null)
            {
                DataContextFactory.GetDataContext().Dispose();
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DataContextFactory.GetDataContext().Set<T>().Where(predicate);
        }

        /// <summary>
        ///     Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">
        ///     An expression of additional properties to eager load. For example: x =>
        ///     x.SomeCollection, x => x.SomeOtherCollection.
        /// </param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = DataContextFactory.GetDataContext().Set<T>();
            return items;
        }

        /// <summary>
        ///     Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="includeProperties">
        ///     An expression of additional properties to eager load. For example: x =>
        ///     x.SomeCollection, x => x.SomeOtherCollection.
        /// </param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = DataContextFactory.GetDataContext().Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }



        /// <summary>
        ///     Adds ab entity to underlying DbContext
        /// </summary>
        /// <param name="entity">the entity that sould be added</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            return DataContextFactory.GetDataContext().Set<T>().Add(entity);
        }


        /// <summary>
        ///     Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        public void Remove(T entity)
        {
            DataContextFactory.GetDataContext().Set<T>().Remove(entity);
        }

        public abstract void SoftDelete(T entity);

        public T Update(T entity)
        {
            DataContextFactory.GetDataContext().Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
