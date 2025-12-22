using System;
// SIMPLE CALCULATOR PROGRAM

class Calculator
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Enter First Number: ");
            double First = double.Parse(Console.ReadLine());

            Console.Write("Enter Operator (+ - * /): ");
            char Operator = Console.ReadLine()[0];

            Console.Write("Enter Second Number: ");
            double Second = double.Parse(Console.ReadLine());
            //operation based on operator
            switch (Operator)
            {
                case '+': Console.WriteLine(First + Second); break;
                case '-': Console.WriteLine(First - Second); break;
                case '*': Console.WriteLine(First * Second); break;
                case '/': Console.WriteLine(Second != 0 ? First / Second : "Divide by Zero"); break;
                default: Console.WriteLine("Invalid Operator"); break;
            }
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
