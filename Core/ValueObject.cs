namespace Core
{
    /// <summary>
    /// Base class for entity that didn't have Id or key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
    }
}