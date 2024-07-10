using Xunit.Abstractions;

namespace ParallelTests;

public class ParallelTests(ITestOutputHelper testOutputHelper)
{
    private List<int> numbers = Enumerable.Range(0, 100).ToList();

    [Fact]
    public void Test1()
    {
        var countBy = numbers.CountBy(n => n > 50);
        foreach (var (key, count) in countBy)
        {
            testOutputHelper.WriteLine($"{key}: {count}");
        }
    }

    [Fact]
    public void Test2()
    {
        var aggregatedScores = numbers.AggregateBy(keySelector: n => n > 50, seed: 0, (score, curr) => score + curr);
        foreach (var (name, investment) in aggregatedScores.Take(2))
        {
            testOutputHelper.WriteLine($"{name}: {investment}");
        }
    }
}