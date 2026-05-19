using System;
using System.Collections.Generic;
using System.Collections;

namespace MoreInterfaceExamples;

public static class Demo_GenericCollections
{
    public static void Run()
    {
        Console.WriteLine("---- 5) Collection Interfaces Demo ----");

        IList list = new ArrayList();
        list.Add("A");
        list.Add("B");
        Console.WriteLine($"IList (ArrayList) count: {list.Count}, item[1]={list[1]}");

        IDictionary dict = new Hashtable();
        dict["id"] = 101;
        dict["name"] = "Meena";
        Console.WriteLine($"IDictionary (Hashtable) name: {dict["name"]}");

        ICollection<int> numbers = new List<int> { 1, 2, 3 };
        numbers.Add(4);
        Console.WriteLine($"ICollection<int> count: {numbers.Count}");

        IList<string> names = new List<string> { "Arjun", "Meena" };
        names.Insert(1, "Karthik");
        Console.WriteLine($"IList<string>: {string.Join(", ", names)}");

        IDictionary<string, int> scores = new Dictionary<string, int>
        {
            ["Arjun"] = 80,
            ["Meena"] = 95
        };
        Console.WriteLine($"IDictionary<TKey,TValue>: Meena => {scores["Meena"]}");

        IReadOnlyCollection<string> roCollection = names;
        IReadOnlyList<string> roList = names;
        Console.WriteLine($"IReadOnlyCollection<string> Count: {roCollection.Count}");
        Console.WriteLine($"IReadOnlyList<string>[0]: {roList[0]}");

        IReadOnlyDictionary<string, int> roDict = scores;
        Console.WriteLine($"IReadOnlyDictionary: Keys={string.Join(", ", roDict.Keys)}");

        ISet<int> set = new HashSet<int> { 1, 1, 2, 3 };
        Console.WriteLine($"ISet<int> unique count: {set.Count}");

#if NET8_0_OR_GREATER
        IReadOnlySet<int> roSet = set;
        Console.WriteLine($"IReadOnlySet<int> contains 2: {roSet.Contains(2)}");
#endif

        Console.WriteLine();
    }
}
