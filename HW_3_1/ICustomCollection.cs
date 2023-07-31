namespace HW_3_1;

/// <summary>
/// A base interface for a custom collections.
/// </summary>
/// <typeparam name="T">Type of the items in the custom collection.</typeparam>
public interface ICustomCollection<T>
{
    /// <summary>
    /// Gets a number of items in the collection.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// This indexer is used to get or set an element by index.
    /// </summary>
    /// <param name="index">An index of the element in the collection.</param>
    /// <returns>An element by provided index.</returns>
    public T this[int index] { get; set; }

    /// <summary>
    /// This method is used to add the item of certain type to the custom collection.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public void Add(T item);

    /// <summary>
    /// This method is used to sort items inside the collection in ascending order.
    /// </summary>
    public void Sort();

    /// <summary>
    /// This method is used to set a default value for an item at the passed index.
    /// </summary>
    /// <param name="index">An index in collection to set a default value.</param>
    public void SetDefaultAt(int index);
}