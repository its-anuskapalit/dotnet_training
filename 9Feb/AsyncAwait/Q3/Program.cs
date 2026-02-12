using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await AAsync();
    }

    static async Task AAsync()
    {
        Console.WriteLine("A Start");
        await BAsync();
        Console.WriteLine("A End");
    }

    static async Task BAsync()
    {
        Console.WriteLine("B Start");
        await Task.Delay(400);
        Console.WriteLine("B End");
    }
}
