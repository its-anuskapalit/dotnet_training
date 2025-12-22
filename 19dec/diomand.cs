using System;

class DiamondPattern
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter Size: ");
            int Size = int.Parse(Console.ReadLine());

            for (int i = 1; i <= Size; i++)
            {
                Console.WriteLine(new string(' ', Size - i) + new string('*', 2 * i - 1));
            }

            for (int i = Size - 1; i >= 1; i--)
            {
                Console.WriteLine(new string(' ', Size - i) + new string('*', 2 * i - 1));
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
