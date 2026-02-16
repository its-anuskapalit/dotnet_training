using System;
using System.Collections.Generic;
using System.Linq;

public enum OrderSide
{
    Buy,
    Sell
}
public class Order
{
    public string OrderId { get; set; }
    public string Instrument { get; set; }
    public OrderSide Side { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Time { get; set; }
}
public class OrderBook
{
    private List<Order> buyOrders = new List<Order>();
    private List<Order> sellOrders = new List<Order>();
    public void AddOrder(Order order)
    {
        if (order.Side == OrderSide.Buy)
            buyOrders.Add(order);
        else
            sellOrders.Add(order);
    }
    public void MatchOrders()
    {
        buyOrders = buyOrders.OrderByDescending(o => o.Price).ToList();
        sellOrders = sellOrders.OrderBy(o => o.Price).ToList();
        foreach (var buy in buyOrders.ToList())
        {
            foreach (var sell in sellOrders.ToList())
            {
                if (buy.Price >= sell.Price && buy.Quantity > 0 && sell.Quantity > 0)
                {
                    int tradedQty = Math.Min(buy.Quantity, sell.Quantity);

                    buy.Quantity -= tradedQty;
                    sell.Quantity -= tradedQty;

                    Console.WriteLine($"Matched {tradedQty} units at price {sell.Price}");
                }
            }
        }
        buyOrders.RemoveAll(o => o.Quantity == 0);
        sellOrders.RemoveAll(o => o.Quantity == 0);
    }
}
class Program
{
    static void Main()
    {
        OrderBook book = new OrderBook();
        book.AddOrder(new Order
        {
            OrderId = "B1",
            Instrument = "AAPL",
            Side = OrderSide.Buy,
            Price = 150,
            Quantity = 10,
            Time = DateTime.Now
        });
        book.AddOrder(new Order
        {
            OrderId = "S1",
            Instrument = "AAPL",
            Side = OrderSide.Sell,
            Price = 140,
            Quantity = 5,
            Time = DateTime.Now
        });
        book.MatchOrders();
    }
}
