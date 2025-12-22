using System;
// DIGITAL ROOT PROGRAM
class DigitalRoot
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter Number: ");
            int Number = int.Parse(Console.ReadLine());

            while (Number >= 10)
            {
                int Sum = 0;
                while (Number > 0)
                {
                    Sum += Number % 10;
                    Number /= 10;
                }
                Number = Sum;
            }
            //output result

            Console.WriteLine("Digital Root: " + Number);
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
