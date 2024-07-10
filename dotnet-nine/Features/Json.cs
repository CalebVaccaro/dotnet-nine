using System.Text.Json;

namespace dotnet_nine.Features;

public class Json
{
    public static void CamelCaseJson()
    {
        var json = JsonSerializer.Serialize(new {SomeValue = "Hello, World!"}, JsonSerializerOptions.Web);
        Console.WriteLine(json);
    }
}