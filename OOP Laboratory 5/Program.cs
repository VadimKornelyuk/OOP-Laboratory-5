public class EbaloNaNolik
{
    public static void Main(string[] args)
    {
        var list = MyClass.FactoryMethod<MyList<int>>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);
        list.Add(7);
        list.Add(8);
        list.Add(9);
        list.Add(10);

        var array = list.GetArray();

        foreach (var el in array)
        {
            Console.WriteLine(el);
        }
    }
}

public class MyList<T>
{
    private T[] _items;
    private int _size;

    public MyList()
    {
        _items = Array.Empty<T>();
    }

    public T this[int index] => _items[index];

    public int Count => _size;

    public void Add(T element)
    {
        if (_size == _items.Length)
            if (_items.Length < _size + 1)
            {
                var newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if ((uint)newCapacity > Array.MaxLength)
                    newCapacity = Array.MaxLength;
                if (newCapacity < _size + 1)
                    newCapacity = _size + 1;
                SetCapacity(newCapacity);
            }
        _items[_size++] = element;
    }

    private void SetCapacity(int newCapacity)
    {
        if (newCapacity < _size)
        {
            throw new ArgumentOutOfRangeException(nameof(newCapacity));
        }

        if (newCapacity == _items.Length)
            return;

        if (newCapacity > 0)
        {
            var newItems = new T[newCapacity];
            if (_size > 0)
            {
                Array.Copy(_items, 0, newItems, 0, _size);
            }
            _items = newItems;
        }
        else
        {
            _items = Array.Empty<T>();
        }
    }
}

public class MyDictionary<TKey, TValue>
{
    private KeyValuePair<TKey, TValue>[] _items;

    private int _size;

    public MyDictionary()
    {
        _items = Array.Empty<KeyValuePair<TKey, TValue>>();
    }

    public KeyValuePair<TKey, TValue> this[int index] => _items[index];

    public int Count => _size;

    public void Add(KeyValuePair<TKey, TValue> element)
    {
        if (_size == _items.Length)
            if (_items.Length < _size + 1)
            {
                var newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if ((uint)newCapacity > Array.MaxLength)
                    newCapacity = Array.MaxLength;
                if (newCapacity < _size + 1)
                    newCapacity = _size + 1;
                SetCapacity(newCapacity);
            }
        _items[_size++] = element;
    }

    private void SetCapacity(int newCapacity)
    {
        if (newCapacity < _size)
        {
            throw new ArgumentOutOfRangeException(nameof(newCapacity));
        }

        if (newCapacity == _items.Length)
            return;

        if (newCapacity > 0)
        {
            var newItems = new KeyValuePair<TKey, TValue>[newCapacity];
            if (_size > 0)
            {
                Array.Copy(_items, 0, newItems, 0, _size);
            }
            _items = newItems;
        }
        else
        {
            _items = Array.Empty<KeyValuePair<TKey, TValue>>();
        }
    }
}

public static class Extensions
{
    public static T[] GetArray<T>(this MyList<T> list)
    {
        var result = new T[list.Count];
        for (var i = 0; i < list.Count; i++)
        {
            result[i] = list[i];
        }

        return result;
    }
}

public static class MyClass
{
    public static T FactoryMethod<T>()
        where T : new()
    {
        return new T();
    }
}
