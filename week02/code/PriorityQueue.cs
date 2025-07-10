/// <summary>
/// A basic implementation of a Priority Queue
/// </summary>
public class PriorityQueue
{
    private class Item
    {
        public string Value { get; set; }
        public int Priority { get; set; }
        public int Order { get; set; } // Keeps track of insertion order

        public Item(string value, int priority, int order)
        {
            Value = value;
            Priority = priority;
            Order = order;
        }

        public override string ToString()
        {
            return $"({Value}, {Priority}, {Order})";
        }
    }

    private readonly List<Item> _queue = new();
    private int _orderCounter = 0; // Counter to keep insertion order

    public int Length => _queue.Count;

    /// <summary>
    /// Add an element to the queue
    /// </summary>
    /// <param name="value">The string value</param>
    /// <param name="priority">The priority of the value</param>
    public void Enqueue(string value, int priority)
    {
        var item = new Item(value, priority, _orderCounter++);
        _queue.Add(item);
    }

    /// <summary>
    /// Remove the element with the highest priority
    /// </summary>
    /// <returns>The string value</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int highPriorityIndex = 0;

        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
            else if (_queue[index].Priority == _queue[highPriorityIndex].Priority &&
                     _queue[index].Order < _queue[highPriorityIndex].Order)
            {
                // Tie in priority: choose the one inserted earlier
                highPriorityIndex = index;
            }
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    /// <summary>
    /// Determine if the queue is empty
    /// </summary>
    /// <returns>True if empty</returns>
    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
