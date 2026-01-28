using System;
namespace GeneratePassWord
{
    class Program
    {
        static string GeneratePassWord(string? username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Invalid username";
            }
            int value = 0;
            string m = username.ToLower();
            int count = 0;
            for (int i = 0; i < m.Length && count < 4; i++)
            {
                if (char.IsLetter(m[i]))
                {
                    value += (int)m[i];
                    count++;
                }
            }
            return "TECH_" + value + username[^2] + username[^1];

        }
        static void Main()
        {
            Console.WriteLine("Enter username");
            string? username = Console.ReadLine();
            string password = GeneratePassWord(username);
            Console.WriteLine("Generated Password: " + password);
        }
    }
}