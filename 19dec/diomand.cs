using System;
// DIAMOND PATTERN PROGRAM

class DiamondPattern
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter Size: ");
            int Size = int.Parse(Console.ReadLine());
            //print diamond pattern
            for (int i = 1; i <= Size; i++)
            {
                Console.WriteLine(new string(' ', Size - i) + new string('*', 2 * i - 1));
            }
            //lower half
            for (int i = Size - 1; i >= 1; i--)
            {
                Console.WriteLine(new string(' ', Size - i) + new string('*', 2 * i - 1));
            }
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
