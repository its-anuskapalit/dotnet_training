using System;
using System.Linq;

class Progran
{
    public static bool Valid(string email)
    {
        string? ch = email;
        bool check = false;
        var special= "&,{}()[]";

        while (!string.IsNullOrEmpty(ch))
        {
            if (ch.EndsWith("@gmail.com") && ch.Count(c => c == '@') == 1 && ch.Count(c => c == '.') == 1 && !special.Any(c => ch.Contains(c)) && ch.Length < 130)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            Console.WriteLine($"Validity of gmail: {check}");
            ch = Console.ReadLine();
        }

        return check;
    }

    public static void Main()
    {
        string email = Console.ReadLine();
        bool check = Valid(email);
        Console.WriteLine($"Validity of gmail: {check}");
    }
}
