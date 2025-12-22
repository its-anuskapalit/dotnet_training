using System;
// FIBONACCI SERIES PROGRAM
class fibonacci
{
    // Function to display Fibonacci series up to n terms
    public static void display()
    {
        int n= int.Parse(Console.ReadLine());
        int firstNumber = 0, secondNumber = 1, nextNumber;
        //  Displaying the Fibonacci series
        Console.WriteLine("Fibonacci Series of the first " + n + " terms:");

        for (int i = 0; i < n; i++)
        {
            if (i <= 1) 
            {
                nextNumber = i;
            }
            // calculating next number
            else
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
            // printing next number
            Console.Write(nextNumber + " ");
        }
    }
}
