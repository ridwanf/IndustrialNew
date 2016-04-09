using Core.DataContextStorage;
using Industrial.Data.Domain;

namespace Industrial.Data.Repositories
{
    /// <summary>
    ///     Manages instances of the ContactManagerContext and stores them in an appropriate storage container.
    /// </summary>
    public static class DataContextFactory
    {
        /// <summary>
        ///     Clear out the current ContactManagerContext
        /// </summary>
        public static void Clear()
        {
            IDataContextStorageContainer<MainDataContext> dataContextStorageContainer =
                DataContextStorageFactory<MainDataContext>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        /// <summary>
        ///     Retrieves an instance of EssContext from the appropriate storage container or
        ///     creates a new instance and stores that in a container.
        /// </summary>
        /// <returns>An instance of EssContext.</returns>
        public static MainDataContext GetDataContext()
        {
            IDataContextStorageContainer<MainDataContext> dataContextStorageContainer =
                DataContextStorageFactory<MainDataContext>.CreateStorageContainer();
            MainDataContext context = dataContextStorageContainer.GetDataContext();
            if (context == null)
            {
                context = new MainDataContext();
                dataContextStorageContainer.Store(context);
            }
            return context;
        }
    }
}