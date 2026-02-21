using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exceptions
public class OutOfStockException : Exception
{
    public OutOfStockException(string msg) : base(msg) { }
}

public class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException(string msg) : base(msg) { }
}

public class CustomerBlacklistedException : Exception
{
    public CustomerBlacklistedException(string msg) : base(msg) { }
}
#endregion

#region Discount Strategy
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal total);
}

public class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _percentage;
    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal total)
    {
        return total - (total * _percentage / 100);
    }
}

public class FlatDiscount : IDiscountStrategy
{
    private readonly decimal _amount;
    public FlatDiscount(decimal amount)
    {
        _amount = amount;
    }

    public decimal ApplyDiscount(decimal total)
    {
        return total - _amount;
    }
}

public class FestivalDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total)
    {
        if (total > 50000)
            return total * 0.8m; 
        return total * 0.9m;
    }
}
#endregion

#region Entities
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsBlacklisted { get; set; }

    public Customer(int id, string name, bool blacklisted = false)
    {
        Id = id;
        Name = name;
        IsBlacklisted = blacklisted;
    }
}

public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice()
    {
        return Product.Price * Quantity;
    }
}

public enum OrderStatus
{
    Pending,
    Shipped,
    Cancelled
}

public class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }

    public decimal GetTotal()
    {
        return Items.Sum(i => i.TotalPrice());
    }

    public decimal GetTotalWithDiscount(IDiscountStrategy strategy)
    {
        return strategy.ApplyDiscount(GetTotal());
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
            throw new OrderAlreadyShippedException("Cannot cancel shipped order");

        Status = OrderStatus.Cancelled;
    }
}
#endregion

class Program
{
    static List<Product> products = new List<Product>();
    static List<Customer> customers = new List<Customer>();
    static List<Order> orders = new List<Order>();
    static Dictionary<int, Product> productDictionary = new Dictionary<int, Product>();

    static void Main()
    {
        SeedData();
        Menu();
    }

    static void SeedData()
    {
        products.Add(new Product(1, "Laptop", 60000, 10));
        products.Add(new Product(2, "Mobile", 30000, 5));
        products.Add(new Product(3, "Headphones", 5000, 50));

        foreach (var p in products)
            productDictionary[p.Id] = p;

        customers.Add(new Customer(1, "Rohan"));
        customers.Add(new Customer(2, "Amit"));
        customers.Add(new Customer(3, "Riya", true));
    }

    static void PlaceOrder()
    {
        Console.WriteLine("Enter Customer Id:");
        int cid = int.Parse(Console.ReadLine());

        var customer = customers.FirstOrDefault(c => c.Id == cid);
        if (customer == null) return;

        if (customer.IsBlacklisted)
            throw new CustomerBlacklistedException("Customer is blacklisted");

        Order order = new Order
        {
            OrderId = orders.Count + 1,
            Customer = customer,
            OrderDate = DateTime.Now,
            Status = OrderStatus.Pending
        };

        Console.WriteLine("Enter Product Id:");
        int pid = int.Parse(Console.ReadLine());

        if (!productDictionary.ContainsKey(pid)) return;

        var product = productDictionary[pid];

        Console.WriteLine("Enter Quantity:");
        int qty = int.Parse(Console.ReadLine());

        if (product.Stock < qty)
            throw new OutOfStockException("Insufficient stock");

        product.Stock -= qty;

        order.Items.Add(new OrderItem
        {
            Product = product,
            Quantity = qty
        });

        orders.Add(order);

        Console.WriteLine("Order Placed Successfully");
    }

    static void Analytics()
    {
        Console.WriteLine("\nOrders in last 7 days:");
        var recent = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-7));
        foreach (var o in recent)
            Console.WriteLine(o.OrderId);

        Console.WriteLine("\nTotal Revenue:");
        Console.WriteLine(orders.Sum(o => o.GetTotal()));

        Console.WriteLine("\nMost Sold Product:");
        var mostSold = orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.Product.Name)
            .OrderByDescending(g => g.Sum(i => i.Quantity))
            .FirstOrDefault();

        if (mostSold != null)
            Console.WriteLine(mostSold.Key);

        Console.WriteLine("\nTop 5 Customers:");
        var topCustomers = orders
            .GroupBy(o => o.Customer.Name)
            .Select(g => new { Name = g.Key, Total = g.Sum(o => o.GetTotal()) })
            .OrderByDescending(x => x.Total)
            .Take(5);

        foreach (var c in topCustomers)
            Console.WriteLine($"{c.Name} - {c.Total}");

        Console.WriteLine("\nGroup by Status:");
        var grouped = orders.GroupBy(o => o.Status);
        foreach (var g in grouped)
            Console.WriteLine($"{g.Key} - {g.Count()}");

        Console.WriteLine("\nLow Stock Products:");
        var lowStock = products.Where(p => p.Stock < 10);
        foreach (var p in lowStock)
            Console.WriteLine(p.Name);
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Place Order");
            Console.WriteLine("2. Analytics");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        PlaceOrder();
                        break;
                    case 2:
                        Analytics();
                        break;
                    case 3:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
