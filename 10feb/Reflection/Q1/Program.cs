using System;
using System.Reflection;
class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
}
class Program
{
    static void Main()
    {
        var type = typeof(Product);
        foreach (var p in type.GetProperties())
            Console.WriteLine($"{p.PropertyType.Name} {p.Name}");
    }
}
