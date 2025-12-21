using System;
//class to Check if a number is prime 
class prime
{
    public static void check()
    {
        //input parse
        int n=int.Parse(Console.ReadLine());
        bool prime= true;
        try{
        for(int i = 2; i * i < n; i++)
        {
            if (n % i == 0)
            {
                prime=false;
            }
        }
        Console.WriteLine(prime? "Prime": "Not Prime");
        }
        catch (NullReferenceException)
        {Console.WriteLine("Null value value");
            
        }
    } 
}
