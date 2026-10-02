namespace Domain;

public class MyQueue<T>
{
    private List<T> _list = [];
    public int Count
    {
        get
        {
            return _list.Count;
        }
    }
    public void Enqueue(T item)
    {
        _list.Add(item);
    }
    public T Dequeue()
    {
        if (_list.Count == 0)
        {
            throw new Exception("Список пустой");
        }
        T item = _list[0];
        _list.RemoveAt(0);
        return item;
    }
    public T Peek()
    {
        if (_list.Count == 0)
        {
            throw new Exception("Лист пустой");
        }
        return _list[0];
    }
    public void Clear()
    {
        _list.Clear();
    }
}
