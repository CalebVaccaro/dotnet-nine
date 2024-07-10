namespace dotnet_nine.Debugging;

public class CollectionsVisualizer
{
    public static void VisualizeCollection()
    {
        var numbers = Enumerable.Range(0, 1000);
        foreach (var number in numbers)
        {
            Console.WriteLine(number * 2);
        }
    }
}