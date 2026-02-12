using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string input = Console.ReadLine();
        await File.WriteAllTextAsync("output.txt", input);
    }
}
