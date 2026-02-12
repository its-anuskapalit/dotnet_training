using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int x = await GetAsync();
        Console.WriteLine(x);
    }

    static async Task<int> GetAsync()
    {
        await Task.Delay(200);
        return 5;
    }
}
