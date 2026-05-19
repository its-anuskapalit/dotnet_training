using System;

namespace MoreInterfaceExamples;

public static class Demo_IAsyncResult
{
    private delegate int AddDelegate(int a, int b);

    public static void Run()
    {
        Console.WriteLine("---- 12) IAsyncResult Demo (Legacy) ----");

        AddDelegate add = (x, y) =>
        {
            System.Threading.Thread.Sleep(200);
            return x + y;
        };

        IAsyncResult ar = add.BeginInvoke(10, 20, null, null);
        Console.WriteLine("Doing other work while Add runs...");
        int result = add.EndInvoke(ar);

        Console.WriteLine($"Result = {result}");
        Console.WriteLine("Note: Prefer Task/async/await in modern .NET.");
        Console.WriteLine();
    }
}
