using System.Security.Cryptography;
using System.Text;

namespace dotnet_nine.Features;

public class Cryptography
{
    public static void OneShotHash()
    {
        var data = Encoding.UTF8.GetBytes("Hello, World!");
        var hash = CryptographicOperations.HashData(HashAlgorithmName.SHA256, data);
        var hashString = Convert.ToBase64String(hash);
        Console.WriteLine(hashString);
        Console.WriteLine("Verify Hashed Data");
        var input = Console.ReadLine();
        var result = VerifyData(input, hashString);
        Console.WriteLine(result ? "Data is verified" : "Data is not verified");
    }

    private static bool VerifyData(string? userInput, string storedHash)
    {
        var data = Encoding.UTF8.GetBytes(userInput);
        var hash = CryptographicOperations.HashData(HashAlgorithmName.SHA256, data);
        var hashString = Convert.ToBase64String(hash);

        return hashString == storedHash;
    }
}