using System;
using System.Collections;

namespace MoreInterfaceExamples;

public static class Demo_IEnumerable_IEnumerator
{
    public static void Run()
    {
        Console.WriteLine("---- 4) IEnumerable + IEnumerator Demo ----");

        var bag = new IntBag(new[] { 10, 20, 30 });
        foreach (var x in bag)
            Console.WriteLine($"Item: {x}");

        Console.WriteLine();
    }

    private sealed class IntBag : IEnumerable
    {
        private readonly int[] _items;
        public IntBag(int[] items) => _items = items;

        public IEnumerator GetEnumerator() => new IntBagEnumerator(_items);

        private sealed class IntBagEnumerator : IEnumerator
        {
            private readonly int[] _items;
            private int _index = -1;

            public IntBagEnumerator(int[] items) => _items = items;

            public object Current => _items[_index];

            public bool MoveNext()
            {
                _index++;
                return _index < _items.Length;
            }

            public void Reset() => _index = -1;
        }
    }
}
