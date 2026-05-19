using System;
class Program
{
    static void CheckEligibilty(int age)
    {
        if(age <1 || age > 90)
        {
            Console.WriteLine("Invalid Age");
        }
        else if(age < 18)
        {
            Console.WriteLine("Cannot Vote");
        }
        else
        {
            Console.WriteLine("Can Vote");
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter you age:");
        int age=int.Parse(Console.ReadLine());
        CheckEligibilty(age);
    }
}