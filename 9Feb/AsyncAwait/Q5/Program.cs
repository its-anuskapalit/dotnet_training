using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        DoWork();
        Console.WriteLine("Main End");
        await Task.Delay(1000);
    }

    static async Task DoWork()
    {
        await Task.Delay(500);
        Console.WriteLine("Work Done");
    }
}
