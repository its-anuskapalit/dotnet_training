using System;
// LARGEST OF THREE NUMBERS PROGRAM

class LargestOfThree
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter First Number: ");
            int First = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int Second = int.Parse(Console.ReadLine());

            Console.Write("Enter Third Number: ");
            int Third = int.Parse(Console.ReadLine());
            //determine largest number
            if (First > Second)
            {
                if (First > Third)
                    Console.WriteLine("Largest: " + First);
                else
                    Console.WriteLine("Largest: " + Third);
            }
            //  second is larger than first
            else
            {
                if (Second > Third)
                    Console.WriteLine("Largest: " + Second);
                else
                    Console.WriteLine("Largest: " + Third);
            }
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
