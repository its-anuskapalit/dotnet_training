using System;
// STRONG NUMBER PROGRAM
class StrongNumber
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter Number: ");
            int Number = int.Parse(Console.ReadLine());

            int Temp = Number;
            int Sum = 0;
            //calculate sum of factorials of digits
            while (Temp > 0)
            {
                int Digit = Temp % 10;
                int Fact = 1;

                for (int i = 1; i <= Digit; i++)
                    Fact *= i;

                Sum += Fact;
                Temp /= 10;
            }
            //output result
            Console.WriteLine(Sum == Number ? "Strong Number" : "Not Strong");
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
