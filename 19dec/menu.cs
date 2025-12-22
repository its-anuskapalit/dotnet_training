using System;

class MenuSystem
{
    public static void Run()
    {
        try
        {
            int Choice;
            do
            {
                Console.WriteLine("\n1. Say Hello\n2. Show Date\n3. Exit");
                Choice = int.Parse(Console.ReadLine());

                switch (Choice)
                {
                    case 1: Console.WriteLine("Hello User"); break;
                    case 2: Console.WriteLine(DateTime.Now); break;
                    case 3: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid Choice"); break;
                }
            }
            while (Choice != 3);
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
