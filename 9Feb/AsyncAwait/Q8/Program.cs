using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var sw = Stopwatch.StartNew();
        await Task.Delay(300);
        await Task.Delay(300);
        await Task.Delay(300);
        sw.Stop();
        Console.WriteLine("Sequential: " + sw.ElapsedMilliseconds);

        sw.Restart();
        var t1 = Task.Delay(300);
        var t2 = Task.Delay(300);
        var t3 = Task.Delay(300);
        await Task.WhenAll(t1, t2, t3);
        sw.Stop();
        Console.WriteLine("Parallel: " + sw.ElapsedMilliseconds);
    }
}
