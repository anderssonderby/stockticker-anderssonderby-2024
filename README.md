# stockticker-anderssonderby-2024

## Description
Simple Stock Price Ticker application consisting of a backend server that generates and streams stock prices using Server-Sent Events (SSE), and a console-based client that receives and displays the stock prices in real-time.

## Prerequisites
- .NET SDK 8
- Git (to clone the repository)
- (Optional, recommended) IDE / Text editor

## Setup / How to run
### Backend Server setup
1. Clone the repository
    > git clone https://github.com/anderssonderby/stockticker-anderssonderby-2024.git
2. Navigate to the backend project directory
    > cd StockTicker/StockTickerBackend
3. Restore dependencies and build the project
    > dotnet restore  
     dotnet build
4. Run the backend server
    > dotnet run
5. Confirm the server is running
    > The server should be listening on http://localhost:5001

### Console Client setup
1. Open a new terminal window
2. Navigate to the client directory
    > cd StockTicker/StockTickerClient
3. Restore dependencies and build the project
   > dotnet restore  
   dotnet build
4. Run the client application
    > dotnet run
5. Observe output
    > The client should display stock prices streamed from the backend server

## Usage
- Start the backend server and ensure it is running before starting the client
- Run the console client. It connects to the server's SSE endpoint and begins displaying real-time stock prices
- Monitor the Output: Stock prices with timestamps will be displayed in the console

## Known Issues
- The stock prices are randomly generated and do not reflect real market data
- The client does not handle network interruptions or server errors gracefully
- The application does not implement authentication or encryption (runs over HTTP)

### Example output:
```
14:30:15 - Bed Bath & Beyond: $523.45
14:30:15 - BlackBerry: $678.90
14:30:16 - GameStop: $345.67
14:30:16 - AMC Entertainment Holdings: $890.12
```

### Assignment (Stock Price Ticker View)

You're tasked with making a "frontend/client" and "backend/server" application, which displays Stock Prices.
You should not spend more than 1-2 hours on this, as it only serves as a common talking point. Furthermore, there will be no penalty for not finishing the assignment completely, as mentioned before, it's just a common talking point.

We would prefer you solve the exercise using C# and .NET Core.

Requirements are as follows:

- Stock Price Model:  
  Should have a price with decimal support  
  Should have a Name, eg: Google, Apple, Microsoft, Berkshire etc.  
  Extend with extra information, if you have the time, but not needed.  
  Generated Prices do not need to look "real". Just a random price is sufficient

- Frontend/Client:  
  Should receive "Stock Price Models" from the backend.  
  These prices should be displayed in a human-readable format  
  This can just be something as simple as a console application

- Backend/Server
  Generate "Stock Price Models" every 1-2 seconds.  
  The generated "Stock Price Models" should be the same set of Stocks (Apple, Google, Microsoft etc.) every time  
  Send the generated prices to the frontend using network communication

