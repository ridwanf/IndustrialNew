namespace Core
{
    /// <summary>
    /// Base class for domain that have Id or transactional entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity int the underlying data store
        /// </summary>
        public T Id { get; set; }



        /// <summary>
        /// Checks if the current domain entity has an identity
        /// </summary>
        /// <returns>True if domain entity is transient (i.e. has no identity yet),
        /// false otherwise</returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }

    }
}
