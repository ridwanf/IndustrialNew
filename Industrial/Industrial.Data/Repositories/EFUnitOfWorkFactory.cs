﻿using Core;

namespace Industrial.Data.Repositories
{
    /// <summary>
    /// Creates new instances of an EF of Work
    /// </summary>
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        //<summary>
        //Creates a new instance of an EFUnitOfWork.
        //</summary>
        public IUnitOfWork Create()
        {
            return Create(false);
        }

        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing data context from the storage container.</param>
        public IUnitOfWork Create(bool forceNew)
        {
            return new EFUnitOfWork(forceNew);
        }
    }
}