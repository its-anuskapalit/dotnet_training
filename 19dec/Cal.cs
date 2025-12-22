using System;
// EVEN OR ODD PROGRAM
class Cal
{
    public static void isEven()
    {
        //input parsing
        Console.WriteLine("Enter a 1 if you want to know a number is even or not");
        int a=int.Parse(Console.ReadLine());
        while (a == 1)
        {
            Console.WriteLine("Enter a number");
            int n=int.Parse(Console.ReadLine());
            if (n % 2 == 0)
        {
            Console.WriteLine("Even");
        }
            //odd case
            else
            {
            Console.WriteLine("Odd");
        }
            //continue prompt
            Console.WriteLine("want to continue type 1");
        int b=int.Parse(Console.ReadLine());
        a=b;
        }
    }
}


