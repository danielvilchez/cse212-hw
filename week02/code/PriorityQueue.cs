/// <summary>
/// A basic implementation of a Priority Queue.
/// </summary>
public class PriorityQueue
{
    private class Item
    {
        public string Value { get; set; }
        public int Priority { get; set; }

        public Item(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"({Value}, {Priority})";
        }
    }

    private readonly List<Item> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add an item to the queue with a specific priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var item = new Item(value, priority);
        _queue.Add(item);
    }

    /// <summary>
    /// Remove the item with the highest priority (larger number = higher priority).
    /// If two items have the same priority, the one added first is removed.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int highPriorityIndex = 0;

        // Only update index if a strictly higher priority is found
        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
