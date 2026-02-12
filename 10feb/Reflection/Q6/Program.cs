// using System;

// public class Employee
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public decimal Salary { get; private set; }

//     private string secretCode = "X9Z";

//     public Employee() { }

//     public Employee(int id, string name, decimal salary)
//     {
//         Id = id;
//         Name = name;
//         Salary = salary;
//     }

//     public void GiveRaise(decimal amount)
//     {
//         Salary += amount;
//     }

//     private string GetSecretCode() => secretCode;
// }

// class Program
// {
//     static void Main()
//     {
//         Employee emp = new Employee(101, "Arun", 45000);

//         Type t1 = typeof(Employee);     // compile-time
//         Type t2 = emp.GetType();        // runtime

//         Console.WriteLine(t1.FullName);
//         Console.WriteLine(t2.FullName);
//         Console.WriteLine(t1 == t2);    // True
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Type t = typeof(Employee);

//         var methods = t.GetMethods(); // public instance + inherited public methods

//         foreach (var m in methods)
//         {
//             Console.WriteLine($"{m.ReturnType.Name} {m.Name}()");
//         }
//     }
// }

using System;
using System.Reflection;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        var type = typeof(Calculator);
        var method = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);

        var instance = Activator.CreateInstance(type);
        var result = method.Invoke(instance, new object[] { 3, 5 });

        Console.WriteLine(result);
    }
}
