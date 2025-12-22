using System;
// PRINT ALL PRIME NUMBERS UPTO N PROGRAM
class primeAll
{
    public static void check()
    {
        int n = int.Parse(Console.ReadLine());
        //loop through numbers from 2 to n
        for (int num = 2; num <= n; num++)
{
    bool prime = true;
            //check if num is prime
            for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0)
        {
            prime = false;
            break;
        }
    }
            //if prime, print the number

            if (prime)
        Console.Write(num + " ");
        }

    }
}