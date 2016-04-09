using Core;

namespace Industrial.Data.Repositories
{
    /// <summary>
    /// Defines a Unit of Work using an EF DbContext under the hood.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork //<T> where T :class 
    {
        /// <summary>
        /// Initializes a new instance of the EFUnitOfWork class.
        /// </summary>
        /// <param name="forceNewContext">When true, clears out any existing data context first.</param>
        public EFUnitOfWork(bool forceNewContext)
        {
            if (forceNewContext)
            {
                DataContextFactory.Clear();
            }
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        public void Dispose()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        /// <param name="resetAfterCommit">When true, clears out the data context afterwards.</param>
        public void Commit(bool resetAfterCommit)
        {
            DataContextFactory.GetDataContext().SaveChanges();
            if (resetAfterCommit)
            {
                DataContextFactory.Clear();
            }
        }

        /// <summary>
        /// Undoes changes to the current DbContext by removing it from the storage container.
        /// </summary>
        public void Undo()
        {
            DataContextFactory.Clear();
        }

        //public void RegisterAmended(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RegisterNew(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RegisterRemoved(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository)
        //{
        //    throw new NotImplementedException();
        //}
    }
}