using System;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== CHAR FUNCTIONS =====");
        CharFunctionsDemo();

        Console.WriteLine("\n===== STRING FUNCTIONS =====");
        StringFunctionsDemo();

        Console.WriteLine("\n===== STRINGBUILDER FUNCTIONS =====");
        StringBuilderDemo();
    }

    static void CharFunctionsDemo()
    {
        char ch = 'A';

        Console.WriteLine(char.IsLetter(ch));
        Console.WriteLine(char.IsDigit('5'));
        Console.WriteLine(char.IsLetterOrDigit('#'));
        Console.WriteLine(char.IsWhiteSpace(' '));
        Console.WriteLine(char.IsUpper('A'));
        Console.WriteLine(char.IsLower('a'));
        Console.WriteLine(char.IsNumber('9'));
        Console.WriteLine(char.IsPunctuation('!'));
        Console.WriteLine(char.IsSymbol('$'));
        Console.WriteLine(char.IsControl('\n'));

        Console.WriteLine(char.ToUpper('b'));
        Console.WriteLine(char.ToLower('Z'));

        Console.WriteLine(char.GetNumericValue('7'));

        char parsed = char.Parse("X");
        Console.WriteLine(parsed);

        if (char.TryParse("Y", out char result))
            Console.WriteLine(result);

        Console.WriteLine(char.Compare('A', 'B'));

        Console.WriteLine(char.GetUnicodeCategory('A'));

        // Unique Logic – Count character types
        string sample = "Pass@123";
        int upper = 0, lower = 0, digits = 0, symbols = 0;

        foreach (char c in sample)
        {
            if (char.IsUpper(c)) upper++;
            else if (char.IsLower(c)) lower++;
            else if (char.IsDigit(c)) digits++;
            else symbols++;
        }

        Console.WriteLine($"Upper:{upper} Lower:{lower} Digits:{digits} Symbols:{symbols}");
    }

    static void StringFunctionsDemo()
    {
        string text = "  SoftwareEngineering  ";

        Console.WriteLine(text.Length);
        Console.WriteLine(text.Trim());
        Console.WriteLine(text.TrimStart());
        Console.WriteLine(text.TrimEnd());
        Console.WriteLine(text.ToUpper());
        Console.WriteLine(text.ToLower());
        Console.WriteLine(text.Contains("ware"));
        Console.WriteLine(text.StartsWith("  Soft"));
        Console.WriteLine(text.EndsWith("  "));
        Console.WriteLine(text.IndexOf("ware"));
        Console.WriteLine(text.Substring(2, 8));
        Console.WriteLine(text.Replace("Software", "Cloud"));

        string sentence = "C# is powerful language";
        string[] words = sentence.Split(' ');
        Console.WriteLine("Word Count: " + words.Length);

        Console.WriteLine(string.Join("-", words));

        Console.WriteLine(string.IsNullOrEmpty(""));
        Console.WriteLine(string.IsNullOrWhiteSpace("   "));

        Console.WriteLine("Admin".Equals("admin", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(string.Compare("apple", "banana"));

        // Reverse string
        string input = "Engineering";
        string reversed = "";

        for (int i = input.Length - 1; i >= 0; i--)
            reversed += input[i];

        Console.WriteLine(reversed);

        // First non-repeating character
        string test = "swiss";
        for (int i = 0; i < test.Length; i++)
        {
            if (test.IndexOf(test[i]) == test.LastIndexOf(test[i]))
            {
                Console.WriteLine("First Non-Repeating: " + test[i]);
                break;
            }
        }
    }

    static void StringBuilderDemo()
    {
        StringBuilder sb = new StringBuilder("Hello");

        Console.WriteLine(sb.Length);
        Console.WriteLine(sb.Capacity);
        Console.WriteLine(sb.MaxCapacity);

        sb.Append(" World");
        sb.AppendLine("!");
        sb.AppendFormat(" Name: {0}, Age: {1}", "Anuska", 22);
        sb.AppendJoin(",", new[] { "A", "B", "C" });

        sb.Insert(0, "Start-");
        sb.Remove(0, 6);
        sb.Replace("Hello", "Hi");

        sb.EnsureCapacity(500);

        char firstChar = sb[0];
        sb[0] = 'X';

        char[] buffer = new char[5];
        sb.CopyTo(0, buffer, 0, 5);

        Console.WriteLine(new string(buffer));

        Console.WriteLine(sb.ToString());
        Console.WriteLine(sb.ToString(0, 5));

        sb.Clear();
        Console.WriteLine("After Clear Length: " + sb.Length);

        // Performance example
        StringBuilder table = new StringBuilder();
        for (int i = 1; i <= 5; i++)
        {
            table.AppendLine($"2 x {i} = {2 * i}");
        }
        Console.WriteLine(table.ToString());
    }
}
