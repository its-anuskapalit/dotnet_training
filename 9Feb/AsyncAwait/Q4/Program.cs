using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await WorkAsync();
    }

    static async Task WorkAsync()
    {
        await Task.Delay(500);
        Console.WriteLine("Done");
    }
}
