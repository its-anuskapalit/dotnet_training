using System;
class Program
{
    static void Main()
    {
        //Ask user for name and greet them
        Console.Write("Enter your name : ");
        //read user input
        String a = Console.ReadLine();
        //greet user
        Console.WriteLine("Hello: " + a + "!");
    }
}
// ================================================================
// PRIME NUMBERS PROGRAM
// Prints all prime numbers less than the given number
// ================================================================
 using System;
 class Program
{
    static void Main()
    {
        //ask user for number
        Console.Write("Enter number: ");
        int a = int.Parse(Console.ReadLine());
        //print all prime numbers less than a
        for (int i = 1; i < a; i += 2)
        {
            int c = 0;
            //xcheck if i is prime
            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    c++;
                    break;
                }
            }
            //if c is 0, i is prime
            if (c == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
//============================================================

 using System;
 class Program
{
    static void Main()
    {
        //ask user for age
        Console.Write("Enter age: ");
        String a = Console.ReadLine();
        //check if age is a valid integer
        if (int.TryParse(a, out int age))
        {
            bool isAdult = age >= 18;
            Console.WriteLine("Adult ? " + isAdult);
        }
        else
        {
            Console.WriteLine("Invalid age.Please enter a whole number. ");
        }
    }
}

//============================================================


using System;
class Program{
    static void Main()
    {
        //ask user for feet
        Console.WriteLine("Feet: ");
        int a=int.Parse(Console.ReadLine());
        //convert feet to centimeters
        double c =30.48*a;
        Console.WriteLine("Centimeters: "+ c);


    }
}
