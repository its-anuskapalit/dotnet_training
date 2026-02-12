using System;
namespace Q13
{
    class Program
    {
        static void Main()
        {
            string text = "Hello world, welcome to programming!";
            char[] remove = { '.', ',', '!', '?' };
            foreach (char c in remove)
            {
                text = text.Replace(c.ToString(), "");
            }
            string[] words = text.Split(' ');
            string longest = "";
            foreach (string w in words)
            {
                if (w.Length > longest.Length)
                {
                    longest = w;
                }
            }
            Console.WriteLine(longest);
        }
    }
}