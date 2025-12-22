using System;
using System.Numerics;
// FACTORIAL PROGRAM FOR LARGE NUMBERS

class FactorialLarge
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter Number: ");
            int Number = int.Parse(Console.ReadLine());
            //calculate factorial using BigInteger
            BigInteger Factorial = 1;

            for (int i = 1; i <= Number; i++)
                Factorial *= i;

            Console.WriteLine("Factorial: " + Factorial);
        }
        //  error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
