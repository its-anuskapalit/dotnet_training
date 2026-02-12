using System;
using System.Collections.Generic;
using System.Linq;

public enum Category { Electronics, Clothing, Books, Groceries }

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; set; }
    Category Category { get; }
}

public class ProductRepository<T> where T : class, IProduct
{
    private readonly List<T> _products = new();

    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException();

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException();

        if (product.Price <= 0)
            throw new ArgumentException();

        if (_products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException();

        _products.Add(product);
    }

    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException();

        return _products.Where(predicate);
    }

    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _products.AsReadOnly();
    }
}

public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

public class BookProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Books;
    public string Author { get; set; }
}

public class DiscountedProduct<T> where T : IProduct
{
    private readonly T _product;
    private readonly decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null)
            throw new ArgumentNullException();

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException();

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | Discounted: {DiscountedPrice}";
    }
}

public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Price}");

        var max = products.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"Most Expensive: {max?.Name}");

        var grouped = products.GroupBy(p => p.Category);
        foreach (var g in grouped)
            Console.WriteLine($"{g.Key}: {g.Count()}");

        foreach (var e in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
            e.Price *= 0.9m;
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        foreach (var p in products)
        {
            try
            {
                p.Price = priceAdjuster(p);
            }
            catch
            {
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<IProduct>();

        var laptop = new ElectronicProduct
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200,
            Brand = "Dell",
            WarrantyMonths = 24
        };

        var phone = new ElectronicProduct
        {
            Id = 2,
            Name = "Phone",
            Price = 800,
            Brand = "Samsung",
            WarrantyMonths = 12
        };

        var book = new BookProduct
        {
            Id = 3,
            Name = "Clean Code",
            Price = 450,
            Author = "Robert C. Martin"
        };

        repo.AddProduct(laptop);
        repo.AddProduct(phone);
        repo.AddProduct(book);

        var samsungProducts = repo.FindProducts(p =>
            p is ElectronicProduct e && e.Brand == "Samsung");

        foreach (var p in samsungProducts)
            Console.WriteLine($"Found: {p.Name}");

        Console.WriteLine($"Total Value: {repo.CalculateTotalValue()}");

        var discountedLaptop = new DiscountedProduct<IProduct>(laptop, 15);
        Console.WriteLine(discountedLaptop);

        var manager = new InventoryManager();
        manager.ProcessProducts(repo.GetAll());

        Console.WriteLine($"Total After Discount: {repo.CalculateTotalValue()}");
    }
}
