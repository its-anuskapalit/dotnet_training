using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource(700);
        await OuterAsync(cts.Token);
    }

    static async Task OuterAsync(CancellationToken token)
    {
        await InnerAsync(token);
    }

    static async Task InnerAsync(CancellationToken token)
    {
        await Task.Delay(1000, token);
    }
}
