using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreInterfaceExamples;

public static class Demo_Comparers
{
    public static void Run()
    {
        Console.WriteLine("---- 6) IComparer<T> + IEqualityComparer<T> Demo ----");

        var people = new List<Person>
        {
            new Person("Meena", "Kumar"),
            new Person("Arjun", "Kumar"),
            new Person("Karthik", "Raj")
        };

        people.Sort(new PersonNameComparer());
        Console.WriteLine("Sorted (LastName, FirstName): " +
            string.Join(" | ", people.Select(p => $"{p.FirstName} {p.LastName}")));

        var set = new HashSet<Person>(new LastNameOnlyEqualityComparer())
        {
            new Person("A", "Kumar"),
            new Person("B", "Kumar"),
            new Person("C", "Raj")
        };
        Console.WriteLine($"HashSet count with LastName comparer: {set.Count}");
        Console.WriteLine();
    }

    private sealed record Person(string FirstName, string LastName);

    private sealed class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            int byLast = string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
            if (byLast != 0) return byLast;

            return string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
        }
    }

    private sealed class LastNameOnlyEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.LastName == y.LastName;
        }

        public int GetHashCode(Person obj) => obj.LastName.GetHashCode();
    }
}
