using System.Text.Json;
using StockTickerClient.Models;

var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5001/StockPrice/stream");
request.Headers.Accept.ParseAdd("text/event-stream");

var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
var body = await response.Content.ReadAsStreamAsync();
var reader = new StreamReader(body);

try
{
    while (!reader.EndOfStream)
    {
        var line = await reader.ReadLineAsync();

        if (string.IsNullOrWhiteSpace(line))
            continue;

        if (line.StartsWith("data:"))
        {
            var json = line.Substring(5).Trim();
            var stockPrice = JsonSerializer.Deserialize<StockPriceModel>(json);

            Console.WriteLine($"{stockPrice.Timestamp:T} - {stockPrice.Name}: ${stockPrice.Price}");
        }
    }
}
finally
{
    // Release objects even if exception is thrown
    reader.Dispose();
    body.Dispose();
    response.Dispose();
    client.Dispose();
}