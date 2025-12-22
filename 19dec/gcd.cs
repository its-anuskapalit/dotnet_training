using System;

class GcdLcm
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter First Number: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int B = int.Parse(Console.ReadLine());

            int X = A, Y = B;

            while (Y != 0)
            {
                int Temp = Y;
                Y = X % Y;
                X = Temp;
            }

            int Gcd = X;
            int Lcm = (A * B) / Gcd;

            Console.WriteLine("GCD: " + Gcd);
            Console.WriteLine("LCM: " + Lcm);
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
