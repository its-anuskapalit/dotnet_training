using System;

namespace MoreInterfaceExamples;

public static class Demo_ICloneable
{
    public static void Run()
    {
        Console.WriteLine("---- 3) ICloneable Demo ----");

        var original = new Employee("Arjun", new Address("Chennai"));
        var clone = (Employee)original.Clone(); // shallow clone

        clone.Name = "Arjun-CLONE";
        clone.Address.City = "Coimbatore"; // changes BOTH due to shared reference

        Console.WriteLine($"Original: {original.Name} | {original.Address.City}");
        Console.WriteLine($"Clone   : {clone.Name} | {clone.Address.City}");
        Console.WriteLine("Note: Because it was shallow, Address reference is shared.");
        Console.WriteLine();
    }

    private sealed class Address
    {
        public string City { get; set; }
        public Address(string city) => City = city;
    }

    private sealed class Employee : ICloneable
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Employee(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public object Clone() => this.MemberwiseClone(); // shallow
    }
}
