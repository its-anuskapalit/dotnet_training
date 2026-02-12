using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i}/10");
            await Task.Delay(200);
        }
    }
}
