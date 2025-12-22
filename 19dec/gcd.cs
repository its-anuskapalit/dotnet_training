using System;
// GCD AND LCM PROGRAM

class GcdLcm
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter First Number: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int B = int.Parse(Console.ReadLine());
            //calculate GCD using Euclidean algorithm
            int X = A, Y = B;

            while (Y != 0)
            {
                int Temp = Y;
                Y = X % Y;
                X = Temp;
            }
            //calculate LCM using GCD
            int Gcd = X;
            int Lcm = (A * B) / Gcd;

            Console.WriteLine("GCD: " + Gcd);
            Console.WriteLine("LCM: " + Lcm);
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
