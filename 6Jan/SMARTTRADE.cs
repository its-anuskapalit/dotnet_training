using System;
using System.Collections.Generic;
namespace SmartTrade
{
  struct PriceSnapshot
    {
        public string? Symbol;
        public decimal Price;
    }  
    abstract class Trade
    {
        public int TradeId {get; set;}
        public string Symbol{get; set;}
        public int Quantity {get;set;}
        public abstract decimal CalculateTradeValue();
        public override string ToString()
        {
            return $"TradeId: {TradeId}, Symbol: {Symbol}, Quantity: {Quantity}";
        }
    }
    class EquityTrade: Trade
    {
        public decimal? MarketPrice {get; set;}
        public override decimal CalculateTradeValue()
        {
            return (MarketPrice?? 0)* Quantity;
        }
    }
    class TradeRepository<T> where T : Trade
    {
        private List<T> trades=new List<T>();
        public void AddTrade(T trade)
        {
            trades.Add(trade);
            TradeAnalytics.TotalTrades++;
            Console.WriteLine("Trade added successfully");
        }
        public List<T> GetTrades()
        {
            return trades;
        }
    }
    static class TradeAnalytics
    {
        public static int TotalTrades=0;
        public static void DisplayAnalytics()
        {
            Console.WriteLine("Total Trades Executed: "+ TotalTrades);
        }
    }
    static class FinanceExtension
    {
        public static decimal  CalculateBrokerage(this decimal amount)
        {
            return amount*0.001m;
        }
        public static decimal CalculateGST(this decimal brokerage)
        {
            return brokerage*0.18m;
        }
    }
    class Program
    {
        static void ProcessTrade(Trade trade)
        {
            if(trade is EquityTrade)
            {
                Console.WriteLine("Processing Equity Trade");
            }
        }
        public static void Main()
        {
           PriceSnapshot snapshot=new PriceSnapshot{Symbol = "AAPL", Price = 150.50m}; 
           Console.WriteLine($"Stock Symbol: {snapshot.Symbol}");
           Console.WriteLine($"Stock Price: {snapshot.Price}");

           TradeRepository<EquityTrade> repository=new TradeRepository<EquityTrade>();
           EquityTrade trade1=new EquityTrade{ TradeId=1, Symbol="AAPL",Quantity=100, MarketPrice=150.5m};
           EquityTrade trade2=new EquityTrade{ TradeId=1, Symbol="MSFT",Quantity=50, MarketPrice=null};
           repository.AddTrade(trade1);
           repository.AddTrade(trade2);
           
           foreach (var trade in repository.GetTrades())
            {
                ProcessTrade(trade);
                decimal value=trade.CalculateTradeValue();
                decimal brokerage=value.CalculateBrokerage();
                decimal gst=brokerage.CalculateGST();
                Console.WriteLine("Trade Value: " + value);
            Console.WriteLine("Brokerage: " + brokerage);
            Console.WriteLine("GST: " + gst);
            Console.WriteLine(trade);
            }
            object boxed = TradeAnalytics.TotalTrades;
        int unboxed = (int)boxed;

        Console.WriteLine("Boxed Trade Count: " + boxed);
        Console.WriteLine("Unboxed Trade Count: " + unboxed);

        TradeAnalytics.DisplayAnalytics();

        }
    }
}