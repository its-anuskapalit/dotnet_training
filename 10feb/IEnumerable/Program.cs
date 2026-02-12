using System;
using System.Collections;
class Numbers : IEnumerable
{
    private int[] data = { 1, 2, 3 };
    public IEnumerator GetEnumerator()
    {
        return data.GetEnumerator();
    }
}
class Program
{
    static void Main()
    {
        var nums = new Numbers();
        foreach (int n in nums)
            Console.WriteLine(n);
    }
}
