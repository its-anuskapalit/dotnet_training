using System;
using System.Reflection;
class Service
{
    public void Run(string msg, int count)
    {
        Console.WriteLine($"Method invoked successfully: {msg} {count}");
    }
}
class Program
{
    static void Main()
    {
        var service = new Service();
        var methodName = "Run";
        var parameters = new object[] { "Hello", 5 };
        var method = service.GetType().GetMethod(methodName);
        method.Invoke(service, parameters);
    }
}
