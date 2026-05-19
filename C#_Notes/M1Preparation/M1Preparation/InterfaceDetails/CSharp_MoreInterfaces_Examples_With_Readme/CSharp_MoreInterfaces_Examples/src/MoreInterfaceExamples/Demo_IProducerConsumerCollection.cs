using System;
using System.Collections.Concurrent;

namespace MoreInterfaceExamples;

public static class Demo_IProducerConsumerCollection
{
    public static void Run()
    {
        Console.WriteLine("---- 7) IProducerConsumerCollection<T> Demo ----");

        IProducerConsumerCollection<int> q = new ConcurrentQueue<int>();
        q.TryAdd(10);
        q.TryAdd(20);
        q.TryTake(out int taken);

        Console.WriteLine($"Taken: {taken}");
        Console.WriteLine($"Count now: {q.Count}");
        Console.WriteLine();
    }
}
