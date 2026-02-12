using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfter(1000);

        try
        {
            while (true)
            {
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine("Working...");
                await Task.Delay(300, cts.Token);
            }
        }
        catch
        {
            Console.WriteLine("Cancelled");
        }
    }
}
