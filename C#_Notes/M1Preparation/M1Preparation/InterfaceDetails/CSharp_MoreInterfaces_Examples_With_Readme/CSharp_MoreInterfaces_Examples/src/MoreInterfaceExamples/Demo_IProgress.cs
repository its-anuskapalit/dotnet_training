using System;
using System.Threading.Tasks;

namespace MoreInterfaceExamples;

public static class Demo_IProgress
{
    public static async Task RunAsync()
    {
        Console.WriteLine("---- 11) IProgress<T> Demo ----");

        IProgress<int> progress = new Progress<int>(p => Console.WriteLine($"Progress: {p}%"));
        await FakeDownloadAsync(progress);

        Console.WriteLine();
    }

    private static async Task FakeDownloadAsync(IProgress<int> progress)
    {
        for (int p = 0; p <= 100; p += 25)
        {
            await Task.Delay(200);
            progress.Report(p);
        }
    }
}
