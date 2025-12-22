using System;
// MENU SYSTEM PROGRAM
class MenuSystem
{
    public static void Run()
    {
        try
        //menu loop
        {
            int Choice;
            //display menu and get choice
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
            //continue until exit chosen
            while (Choice != 3);
        }
        //  error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
