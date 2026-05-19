// using System;
// using System.Collections.Generic;
// class NonGenericPrinter
// {
//     public void Print(int value)
//     {
//         Console.WriteLine("Non-Generic Value: " + value);
//     }
// }
// class GenericPrinter<T>
// {
//     public void Print(T value)
//     {
//         Console.WriteLine("Generic Value: " + value);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         NonGenericPrinter ng = new NonGenericPrinter();
//         ng.Print(10);
//         GenericPrinter<int> gInt = new GenericPrinter<int>();
//         gInt.Print(20);
//         GenericPrinter<string> gString = new GenericPrinter<string>();
//         gString.Print("Hello");
//         GenericPrinter<double> gDouble = new GenericPrinter<double>();
//         gDouble.Print(99.99);
//     }
// }

// using System;

// class NonGenericBox
// {
//     public int Value;

//     public void Show()
//     {
//         Console.WriteLine(Value);
//     }
// }

// class GenericBox<T>
// {
//     public T Value;

//     public void Show()
//     {
//         Console.WriteLine(Value);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         NonGenericBox box1 = new NonGenericBox();
//         box1.Value = 10;
//         box1.Show();

//         GenericBox<int> box2 = new GenericBox<int>();
//         box2.Value = 20;
//         box2.Show();

//         GenericBox<string> box3 = new GenericBox<string>();
//         box3.Value = "Hello";
//         box3.Show();
//     }
// }

// using System;
// class Program
// {
//     static void Main()
//     {
//         string name = "ANUSHKA";
//         char[] charArray = name.ToCharArray(); 
//         int i = 0;
//         int j = name.Length - 1; 
//         while (i < j)
//         {
//             char temp = charArray[i];
//             charArray[i] = charArray[j];
//             charArray[j] = temp;
//             i++;
//             j--;
//         }
//         string reversedName = new string(charArray);
//         Console.WriteLine(name);
//         Console.WriteLine(reversedName);
//     }
// }

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         string input = "anuska";
//         var characterCount = new Dictionary<char, int>();
//         foreach (char c in input)
//         {
//             if (characterCount.ContainsKey(c))
//             {
//                 characterCount[c]++;
//             }
//             else
//             {
//                 characterCount.Add(c, 1);
//             }
//         }
//         foreach (var pair in characterCount)
//         {
//             Console.WriteLine($"Character '{pair.Key}': {pair.Value} times");
//         }
//     }
// }


using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Write("Enter word1: ");
        string word1 = Console.ReadLine();
        Console.Write("Enter word2: ");
        string word2 = Console.ReadLine();
        int deletions = CountDeletions(word1, word2);
        Console.WriteLine("Number of deletions required: " + deletions);
    }
    static int CountDeletions(string word1, string word2)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in word2)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }
        int deletions = 0;
        foreach (char c in word1)
        {
            if (freq.ContainsKey(c) && freq[c] > 0)
            {
                freq[c]--;
            }
            else
            {
                deletions++;
            }
        }
        return deletions;
    }
}