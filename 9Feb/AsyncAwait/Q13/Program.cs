using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var work = Task.Delay(1000);
        var timeout = Task.Delay(500);

        var done = await Task.WhenAny(work, timeout);
        Console.WriteLine(done == work ? "Completed" : "Timeout");
    }
}
