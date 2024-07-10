using System.Text.Json.Serialization;

namespace dotnet_nine.Features;

[JsonPolymorphic]
[JsonDerivedType(typeof(Stock), nameof(Stock))]
[JsonDerivedType(typeof(Bond), nameof(Bond))]
public class Investment
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal Total => Price * Quantity;
}

public class Stock : Investment
{
    public string Company { get; set; }
    public decimal Dividend { get; set; }
}

public class Bond : Investment
{
    public decimal Coupon { get; set; }
    public decimal Yield { get; set; }
}

public class Hub
{
    public static void ReadInvestment(Investment investment)
    {
        switch (investment)
        {
            case Stock:
                Console.WriteLine("Stock Investment");
                break;
            case Bond:
                Console.WriteLine("Bond Investment");
                break;
            default:
                Console.WriteLine("Raw Investment");
                break;
        }
    }
}