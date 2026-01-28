using System;
namespace YouNameIsMine
{
    class Program
    {
        static bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }
        static bool IsSubsequence(string a, string b)
        {
            int i = 0, j = 0;
            while (i < a.Length && j < b.Length)
            {
                if (char.ToLower(a[i]) == char.ToLower(b[j]))
                    i++;
                j++;
            }
            return i == a.Length;
        }
        static int CompatibilityScore(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= m; j++)
                dp[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (char.ToLower(a[i - 1]) == char.ToLower(b[j - 1]))
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(
                            dp[i - 1, j],
                            Math.Min(dp[i, j - 1], dp[i - 1, j - 1])
                        );
                }
            }

            return dp[n, m];
        }
        static void Main()
        {
            Console.WriteLine("Enter men name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter women name");
            string name2 = Console.ReadLine();

            bool valid1 = IsValidName(name1);
            bool valid2 = IsValidName(name2);

            if (!valid1 && !valid2)
            {
                Console.WriteLine("Both name1 and name2 are invalid names");
                return;
            }

            if (!valid1)
            {
                Console.WriteLine("name1 is an invalid name");
                return;
            }

            if (!valid2)
            {
                Console.WriteLine("name2 is an invalid name");
                return;
            }

            string n1 = name1.Replace(" ", "");
            string n2 = name2.Replace(" ", "");

            if (IsSubsequence(n1, n2) || IsSubsequence(n2, n1))
            {
                Console.WriteLine("name1 and name2 are made for each other");
                Console.WriteLine($"Compatibility Score: {CompatibilityScore(n1, n2)}");
            }

            else
            {
                Console.WriteLine("Both name1 and name2 are not made for each other");
            }
        }
    }
}
