using System.Collections;

namespace HW_3_1;

/// <summary>
/// The custom collection of T elements.
/// </summary>
/// <typeparam name="T">Type of the collection elements.</typeparam>
public sealed class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
{
    private T[] _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyCustomCollection{T}"/> class.
    /// </summary>
    public MyCustomCollection()
    {
        _items = Array.Empty<T>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyCustomCollection{T}"/> class.
    /// </summary>
    /// <param name="collection">A collection of T elements.</param>
    public MyCustomCollection(T[] collection)
    {
        _items = collection;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyCustomCollection{T}"/> class.
    /// </summary>
    /// <param name="capacity">The initial number of elements.</param>
    /// <exception cref="ArgumentOutOfRangeException">The instance of <see cref="ArgumentOutOfRangeException"/> class.</exception>
    public MyCustomCollection(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "The capacity of the collection is too small.");
        }

        _items = new T[capacity];
    }

    /// <summary>
    /// Gets a number of items in the collection.
    /// </summary>
    public int Count => _items.Length;

    /// <summary>
    /// This indexer is used to get or set an element by index.
    /// </summary>
    /// <param name="index">An index of the element in the collection.</param>
    /// <returns>An element by provided index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The instance of <see cref="ArgumentOutOfRangeException"/> class.</exception>
    public T this[int index]
    {
        get
        {
            if (index >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of the range.");
            }

            return _items[index];
        }

        set
        {
            if (index >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of the range.");
            }

            _items[index] = value;
        }
    }

    /// <summary>
    /// This method is used to add the item of certain type to the custom collection.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public void Add(T item)
    {
        Array.Resize(ref _items, _items.Length + 1);

        _items[^1] = item;
    }

    /// <summary>
    /// This method is used to sort items inside the collection in ascending order.
    /// </summary>
    public void Sort() => Array.Sort(_items);

    /// <summary>
    /// This method is used to set a default value for an item at the passed index.
    /// </summary>
    /// <param name="index">An index in collection to set a default value.</param>
    /// <exception cref="ArgumentOutOfRangeException">The instance of <see cref="ArgumentOutOfRangeException"/> class.</exception>
    public void SetDefaultAt(int index)
    {
        if (index < 0 || index >= _items.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of the range.");
        }

        _items[index] = default!;
    }

    /// <summary>
    /// This method is used to support foreach semantics. Implementation of IEnumerable (generic).
    /// </summary>
    /// <returns>
    /// An IEnumerator for this enumerable of T. The enumerator provides a simple way to access all the contents of a collection.
    /// </returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in _items)
        {
            yield return item;
        }
    }

    /// <summary>
    /// This method is used to support foreach semantics. Implementation of IEnumerable (non-generic).
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}