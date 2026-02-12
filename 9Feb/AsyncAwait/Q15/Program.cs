using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string text = await File.ReadAllTextAsync("data.txt");
        Console.WriteLine(text);
    }
}
