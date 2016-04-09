using System;

namespace Core
{
    /// <summary>
    /// Represents a unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable //where T : class
    {
        /// <summary>
        /// Commits the changes to the underlying data store. 
        /// </summary>
        /// <param name="resetAfterCommit">When true, all the previously retrieved objects should be cleared from the underlying model / cache.</param>
        void Commit(bool resetAfterCommit);
        /// <summary>
        /// Undoes all changes to the entities in the model.
        /// </summary>
        void Undo();

        //void RegisterAmended(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository);
        //void RegisterNew(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository);
        //void RegisterRemoved(T entity, IUnitOfWorkRepository<T> unitOfWorkRepository);
    }
}