using System;
using System.Numerics;

class FactorialLarge
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter Number: ");
            int Number = int.Parse(Console.ReadLine());

            BigInteger Factorial = 1;

            for (int i = 1; i <= Number; i++)
                Factorial *= i;

            Console.WriteLine("Factorial: " + Factorial);
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
