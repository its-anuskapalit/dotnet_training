using System;

class LargestOfThree
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter First Number: ");
            int First = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int Second = int.Parse(Console.ReadLine());

            Console.Write("Enter Third Number: ");
            int Third = int.Parse(Console.ReadLine());

            if (First > Second)
            {
                if (First > Third)
                    Console.WriteLine("Largest: " + First);
                else
                    Console.WriteLine("Largest: " + Third);
            }
            else
            {
                if (Second > Third)
                    Console.WriteLine("Largest: " + Second);
                else
                    Console.WriteLine("Largest: " + Third);
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
