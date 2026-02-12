using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var slow = Task.Delay(800).ContinueWith(_ => "Slow");
        var fast = Task.Delay(300).ContinueWith(_ => "Fast");

        var first = await Task.WhenAny(slow, fast);
        Console.WriteLine(await first);
    }
}
