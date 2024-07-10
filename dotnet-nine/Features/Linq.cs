using System.Buffers;

namespace dotnet_nine.Features;

public class Linq
{
    public static void CountBy()
    {
        var numbers = Enumerable.Range(0, 100);
        var countBy = numbers.CountBy(n => n > 50);
        foreach (var (key, count) in countBy)
        {
            Console.WriteLine($"{key}: {count}");
        }
    }

    public static void AggregateInvestments()
    {
        (string name, int investment)[] data = [("Alice", 100), ("Bob", 200), ("Alice", 300), ("Bob", 400), ("Milly", 1000)];
        var aggregatedScores = data.AggregateBy(keySelector: e => e.name, seed: 0, (score, curr) => score + curr.investment);
        foreach (var (name, investment) in aggregatedScores.Take(2))
        {
            Console.WriteLine($"{name}: {investment}");
        }
        
        var maxScore = aggregatedScores.MaxBy(e => e.Value);
        Console.WriteLine($"Investor with the highest investment: {maxScore.Key}, {maxScore.Value}");
    }

    public static void IndexValues()
    {
        var dbLines = File.ReadAllLines("data.txt");
        foreach ((int index, string line) in dbLines.Index())
        {
            // line value starts at 0
            Console.WriteLine($"{index + 1}: {line}");
        }
    }

    public static void ParamOverload()
    {
        string result = string.Join(",", "d", "d", "dasd", "adfadfa", "-end");
        Console.WriteLine(result);
    }

    public static void SearchValuesWithIndex()
    {
        SearchValues<string> searchValues = SearchValues.Create(["hello", "world", "c#", "dotnet", "nine"], StringComparison.OrdinalIgnoreCase);
        var text = "Hello, World!, I love C# and Dotnet Nine. Although, I am still learning C# and Dotnet Nine, I am enjoying it. Still, I have a long way to go. I am excited to learn more about C# and Dotnet Nine.";
        var result = text.AsSpan().IndexOfAny(searchValues);
        Console.WriteLine(result);
    }
}