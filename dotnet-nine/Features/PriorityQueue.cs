namespace dotnet_nine.Features;

public class PriorityQueue
{
    public static void RemoveFromQueue()
    {
        var priorityQueue = new PriorityQueue<int, int>();
        priorityQueue.Enqueue(1, 1);
        priorityQueue.Enqueue(2, 6);
        priorityQueue.Enqueue(3, 10);
        priorityQueue.Enqueue(4, 4);
        
        // Remove the item with the highest priority
        // EqualityComperer is used to compare the values
        priorityQueue.Remove(3, out var value, out var priority, new IntValues());
        priority *= 2;
        
        priorityQueue.Enqueue(value, priority);
        var dequeuedValue = priorityQueue.Dequeue();
        
        Console.WriteLine($"Removed item with value {value} and priority {priority}");
        Console.WriteLine($"Dequeued item with value {dequeuedValue}");
    }
}

class IntValues : EqualityComparer<int>
{
    public override bool Equals(int x, int y) => x == y;
    public override int GetHashCode(int obj) => obj.GetHashCode();
}