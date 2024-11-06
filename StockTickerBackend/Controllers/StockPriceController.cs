using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StockTickerBackend.Services;

namespace StockTickerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class StockPriceController(ILogger<StockPriceController> logger, StockPriceGenerator stockPriceGenerator) : ControllerBase
{
    // Primary constructors = cool, if everyone is on board
    // public StockPriceController(ILogger<StockPriceController> logger, StockPriceGenerator stockPriceGenerator)
    // {
    //     _logger = logger;
    //     _stockPriceGenerator = stockPriceGenerator;
    // }
    
    [HttpGet("stream")]
    public async Task GetStream()
    {
        Response.Headers["Content-Type"] = "text/event-stream";

        await foreach (var stockPrice in stockPriceGenerator.GeneratePricesAsync(HttpContext.RequestAborted))
        {
            logger.LogInformation($"Received stock price: {stockPrice}");
            
            var json = JsonSerializer.Serialize(stockPrice);

            await Response.WriteAsync($"data: {json}\n\n");
            
            logger.LogInformation($"Sent stock price: {stockPrice.Name} to client");
            
            await Response.Body.FlushAsync();
        }
        
    }
}