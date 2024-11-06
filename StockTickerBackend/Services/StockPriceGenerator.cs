using System.Runtime.CompilerServices;
using StockTickerBackend.Models;

namespace StockTickerBackend.Services;

public class StockPriceGenerator
{
    private static readonly string[] StockNames = new[]
    {
        "Bed Bath & Beyond", "BlackBerry", "GameStop", "AMC Entertainment Holdings"
    };
    
    private readonly Random _random = new();

    public async IAsyncEnumerable<StockPriceModel> GeneratePricesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            foreach (var stockName in StockNames)
            {
                var stockPrice = new StockPriceModel(Name: stockName,
                    Price: Math.Round((decimal)(_random.NextDouble() * 1000), 2), Timestamp: DateTime.UtcNow);
                
                yield return stockPrice;
            }
            
            await Task.Delay(1800, cancellationToken);
        }
    }
}