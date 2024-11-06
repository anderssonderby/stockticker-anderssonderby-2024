namespace StockTickerClient.Models;

public class StockPriceModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime Timestamp { get; set; }
}