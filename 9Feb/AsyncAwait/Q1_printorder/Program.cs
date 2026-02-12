using System;
class Program
{
    static async Task Main()
    {
        await PrintAsync();
    }
    static async Task PrintAsync()
    {
        Console.WriteLine("Start");
        await Task.Delay(500);
        Console.WriteLine("End");
    }
}