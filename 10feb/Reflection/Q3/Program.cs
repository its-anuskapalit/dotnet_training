using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
class MaxLengthAttribute : Attribute
{
    public int Length { get; }
    public MaxLengthAttribute(int length) => Length = length;
}

class Product
{
    [MaxLength(10)]
    public string Name { get; set; }
}

class Program
{
    static void Validate(object obj)
    {
        foreach (var p in obj.GetType().GetProperties())
        {
            var attr = p.GetCustomAttribute<MaxLengthAttribute>();
            if (attr != null)
            {
                var value = (string)p.GetValue(obj);
                if (value != null && value.Length > attr.Length)
                    throw new Exception("Max length exceeded");
            }
        }
    }

    static void Main()
    {
        var product = new Product { Name = "VeryLongProductName" };
        Validate(product);
    }
}
