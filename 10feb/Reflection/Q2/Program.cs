using System;

class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
}
class Program
{
    static void Print(object obj)
    {
        foreach (var p in obj.GetType().GetProperties())
        {
            Console.WriteLine($"{p.Name} = {p.GetValue(obj)}");
        }
    }
    static void Main()
    {
        var product = new Product { Name = "Laptop", Price = 50000 };
        Print(product);
    }
}