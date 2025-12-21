using System;
class Cal
{
    public static void isEven()
    {
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
        else
        {
            Console.WriteLine("Odd");
        }
        Console.WriteLine("want to continue type 1");
        int b=int.Parse(Console.ReadLine());
        a=b;
        }
    }
}


