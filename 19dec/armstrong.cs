using System;
// ARMSTRONG NUMBER PROGRAM
class ArmstrongNumber
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter Number: ");
            int Number = int.Parse(Console.ReadLine());

            int Temp = Number;
            int Digits = Number.ToString().Length;
            int Sum = 0;
            //calculate sum of digits raised to the power of number of digits
            while (Temp > 0)
            {
                int Digit = Temp % 10;
                Sum += (int)Math.Pow(Digit, Digits);
                Temp /= 10;
            }

            Console.WriteLine(Sum == Number ? "Armstrong Number" : "Not Armstrong");
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
