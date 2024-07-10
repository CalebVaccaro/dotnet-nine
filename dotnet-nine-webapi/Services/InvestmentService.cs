using dotnet_nine.Features;

namespace dotnet_nine_webapi.Services;

public class InvestmentService
{
    private List<Investment> Investments = new List<Investment>();
    
    public void CreateInvestment(Investment investment)
    {
        Investments.Add(investment);
    }
    
    public List<Investment> GetInvestments()
    {
        return Investments;
    }
    
    public Investment GetInvestment(string symbol)
    {
        return Investments.FirstOrDefault(i => i.Symbol == symbol);
    }
    
    public void UpdateInvestment(string symbol, Investment investment)
    {
        var index = Investments.FindIndex(i => i.Symbol == symbol);
        Investments[index] = investment;
    }
    
    public void DeleteInvestment(string symbol)
    {
        Investments.RemoveAll(i => i.Symbol == symbol);
    }
    
    public decimal CalculateTotalInvestment()
    {
        return Investments.Sum(i => i.Total);
    }
    
    public decimal CalculateTotalInvestment(string symbol)
    {
        return Investments.Where(i => i.Symbol == symbol).Sum(i => i.Total);
    }
    
    private decimal CalculateTotalInvestment<T>() where T : Investment
    {
        return Investments.OfType<T>().Sum(i => i.Total);
    }
    
    private List<T> GetInvestments<T>() where T : Investment
    {
        return Investments.OfType<T>().ToList();
    }
    
    public List<Stock> GetStocks()
    {
        return GetInvestments<Stock>();
    }
    
    public List<Bond> GetBonds()
    {
        return GetInvestments<Bond>();
    }
    
    public decimal CalculateTotalStockInvestment()
    {
        return CalculateTotalInvestment<Stock>();
    }
    
    public decimal CalculateTotalBondInvestment()
    {
        return CalculateTotalInvestment<Bond>();
    }
}