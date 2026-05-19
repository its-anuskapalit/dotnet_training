using System;
using System.Data.Common;
class Program{
    static bool CheckPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }
        if(n==2 || n == 3)
        {
            return true;
        }
        if (n % 2 == 0)
        {
            return false;   
        }
        for(int i = 3;i*i <= n; i += 2)
        {
            if(n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        Console.WriteLine("Enter your number: ");
        int n = int.Parse(Console.ReadLine());
        bool result = CheckPrime(n);
        if(result == true)
        {
            Console.WriteLine($"{n} is a prime number");
        }
        else
        {
            Console.WriteLine($"{n} is a not prime number");
        }
    }
}