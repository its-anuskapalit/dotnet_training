using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string data = await FetchUserAsync();
        Console.WriteLine(data);
    }

    static async Task<string> FetchUserAsync()
    {
        await Task.Delay(700);
        return "{ id: 1, name: 'User' }";
    }
}
