using System;
class fibonacci
{
    public static void display()
    {
        int n= int.Parse(Console.ReadLine());
        int firstNumber = 0, secondNumber = 1, nextNumber;

        Console.WriteLine("Fibonacci Series of the first " + n + " terms:");

        for (int i = 0; i < n; i++)
        {
            if (i <= 1) 
            {
                nextNumber = i;
            }
            else
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
            Console.Write(nextNumber + " ");
        }
    }
}
