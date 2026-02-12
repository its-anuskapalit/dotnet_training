using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int n = await GetNumberAsync();
        Console.WriteLine(n);
    }

    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(300);
        return 99;
    }
}
