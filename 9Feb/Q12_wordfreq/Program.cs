using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "Dot net dot NET Dot";
        string[] words = text.ToLower().Split(' ');

        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach (string w in words)
        {
            if (freq.ContainsKey(w))
                freq[w]++;
            else
                freq[w] = 1;
        }

        foreach (var item in freq)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}
