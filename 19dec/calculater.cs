using System;

class Calculator
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter First Number: ");
            double First = double.Parse(Console.ReadLine());

            Console.Write("Enter Operator (+ - * /): ");
            char Operator = Console.ReadLine()[0];

            Console.Write("Enter Second Number: ");
            double Second = double.Parse(Console.ReadLine());

            switch (Operator)
            {
                case '+': Console.WriteLine(First + Second); break;
                case '-': Console.WriteLine(First - Second); break;
                case '*': Console.WriteLine(First * Second); break;
                case '/': Console.WriteLine(Second != 0 ? First / Second : "Divide by Zero"); break;
                default: Console.WriteLine("Invalid Operator"); break;
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
