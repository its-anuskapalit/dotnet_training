using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the size");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements");
        List<int> input = new List<int>();
        for (int i = 0; i < size; i++)
        {
            int a = int.Parse(Console.ReadLine());
            input.Add(a);
        }
        HashSet<int> output = new HashSet<int>(input);
        Console.WriteLine(string.Join(" , ", output));
    }
}