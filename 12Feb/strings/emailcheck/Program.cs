using System;
class Progran
{
    public static bool Valid(string email)
    {
        string? ch = email;
        bool check = false;
        while (!string.IsNullOrEmpty(ch))
        {
            if ((email.EndsWith("@gmail.com")) && (email.Count(c => c == '@') == 1) && (email.Count(c => c == '.') == 1))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            Console.WriteLine(check);
            ch = Console.ReadLine();
        }
        return check;

    }
    public static void Main()
    {
        string email = Console.ReadLine();
        bool check = Valid(email);
        Console.WriteLine(check);
    }
}