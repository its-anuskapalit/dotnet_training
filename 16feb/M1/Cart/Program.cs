using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> cartItems;
    public ShoppingCart()
    {
        cartItems = new Dictionary<T, int>();
    }
    public void AddToCart(T product, int quantity)
    {
        if (cartItems.ContainsKey(product))
        {
            cartItems[product] = cartItems[product] + quantity;
        }
        else
        {
            cartItems.Add(product, quantity);
        }
    }
    public double CalculateTotal(Func<T, double, double> discountFunction = null)
    {
        double totalAmount = 0;
        foreach (KeyValuePair<T, int> entry in cartItems)
        {
            T product = entry.Key;
            int quantity = entry.Value;
            double itemTotal = product.Price * quantity;

            if (discountFunction != null)
            {
                itemTotal = discountFunction(product, itemTotal);
            }

            totalAmount += itemTotal;
        }

        return totalAmount;
    }
    public List<T> GetTopExpensiveItems(int count)
    {
        List<T> products = cartItems.Keys.ToList();
        products.Sort((a, b) => b.Price.CompareTo(a.Price));
        List<T> result = new List<T>();
        for (int i = 0; i < count && i < products.Count; i++)
        {
            result.Add(products[i]);
        }

        return result;
    }
}
class Electronics : Product { }
class Clothing : Product { }
class Program
{
    static void Main()
    {
        ShoppingCart<Electronics> cart = new ShoppingCart<Electronics>();

        Electronics laptop = new Electronics
        {
            Id = 1,
            Name = "Laptop",
            Price = 1000
        };

        Electronics mouse = new Electronics
        {
            Id = 2,
            Name = "Mouse",
            Price = 50
        };

        cart.AddToCart(laptop, 1);
        cart.AddToCart(mouse, 2);

        double total = cart.CalculateTotal((product, price) =>
        {
            if (price > 100)
                return price * 0.9;
            else
                return price;
        });

        Console.WriteLine("Total After Discount: " + total);

        List<Electronics> topItems = cart.GetTopExpensiveItems(1);

        if (topItems.Count > 0)
        {
            Console.WriteLine("Most Expensive Item: " + topItems[0].Name);
        }
    }
}
