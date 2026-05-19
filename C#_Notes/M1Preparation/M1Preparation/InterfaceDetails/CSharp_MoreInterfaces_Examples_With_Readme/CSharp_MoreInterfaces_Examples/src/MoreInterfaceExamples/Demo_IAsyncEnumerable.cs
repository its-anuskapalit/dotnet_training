using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoreInterfaceExamples;

public static class Demo_IAsyncEnumerable
{
    public static async Task RunAsync()
    {
        Console.WriteLine("---- 8) IAsyncEnumerable<T> + IAsyncEnumerator<T> Demo ----");

        await foreach (var x in GenerateNumbersAsync())
        {
            Console.WriteLine($"Async item: {x}");
        }

        Console.WriteLine();
    }

    private static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 1; i <= 3; i++)
        {
            await Task.Delay(200);
            yield return i;
        }
    }
}
