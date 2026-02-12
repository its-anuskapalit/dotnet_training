using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var t1 = Task.Delay(200).ContinueWith(_ => "A");
        var t2 = Task.Delay(400).ContinueWith(_ => "B");
        var t3 = Task.Delay(700).ContinueWith(_ => "C");

        var results = await Task.WhenAll(t1, t2, t3);
        Console.WriteLine(string.Join(", ", results));
    }
}
