namespace dotnet_nine.Features;

public class NewTimespan
{
    public static void CreateTimespanFromInt()
    {
        var timeSpan = TimeSpan.FromMinutes(minutes: 99, seconds: 101, milliseconds: 22, microseconds: 11);
        Console.WriteLine(timeSpan);
    }
}