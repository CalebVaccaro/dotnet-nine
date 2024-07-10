using System.Threading.Channels;

namespace dotnet_nine.Features;

public class Threading
{
    public static async void WhenEach()
    {
        var tasks = new List<Task>
        {
            Task.Run(() =>
            {
                Task.Delay(4000);
                Console.WriteLine("Task 1");
            }),
            Task.Run(() => Console.WriteLine("Task 2")),
            Task.Run(() => Console.WriteLine("Task 3"))
        };

        await foreach (var task in Task.WhenEach(tasks))
        {
            Console.WriteLine($"Task {task.Id} completed");
        }
    }

    public static async void PrioritizedThreads()
    {
        var c = Channel.CreateUnboundedPrioritized<int>(new UnboundedPrioritizedChannelOptions<int>()
        {
            Comparer = Comparer<int>.Create((x, y) => (x < y) ? 1 : -1)
        });
        //var c = Channel.CreateBounded<int>(10);
        await c.Writer.WriteAsync(1);
        await c.Writer.WriteAsync(5);
        await c.Writer.WriteAsync(2);
        await c.Writer.WriteAsync(4);
        await c.Writer.WriteAsync(3);
        await c.Writer.WriteAsync(6);
        c.Writer.Complete();

        while (await c.Reader.WaitToReadAsync())
        {
            while (c.Reader.TryRead(out var item))
            {
                Console.WriteLine(item);
            }
        }
    }
}