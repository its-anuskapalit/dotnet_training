using System;
using System.Collections.Generic;

class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message) { }
}
class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}
class DailyLimitExceededException : Exception
{
    public DailyLimitExceededException(string message) : base(message) { }
}

class Product
{
    public int Id { get; set; }
    public int Stock { get; set; }
}

class OrderService
{
    private Dictionary<int, Product> products = new Dictionary<int, Product>();
    private const int DailyLimit = 5;

    public OrderService()
    {
        products[1] = new Product { Id = 1, Stock = 10 };
    }

    public void PlaceOrder(int productId, int quantity)
    {
        if (!products.ContainsKey(productId))
            throw new ProductNotFoundException("Product does not exist.");

        if (quantity > DailyLimit)
            throw new DailyLimitExceededException("Daily purchase limit exceeded.");

        Product product = products[productId];

        if (product.Stock < quantity)
            throw new OutOfStockException("Insufficient stock.");

        product.Stock -= quantity;
        Console.WriteLine("Order placed successfully.");
    }
}

class Program
{
    static void Main()
    {
        OrderService service = new OrderService();

        try
        {
            service.PlaceOrder(1, 6);
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OutOfStockException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DailyLimitExceededException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
