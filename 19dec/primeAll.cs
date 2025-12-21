using System;
class primeAll
{
    public static void check()
    {
        int n = int.Parse(Console.ReadLine());

for (int num = 2; num <= n; num++)
{
    bool prime = true;

    for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0)
        {
            prime = false;
            break;
        }
    }

    if (prime)
        Console.Write(num + " ");
        }

    }
}