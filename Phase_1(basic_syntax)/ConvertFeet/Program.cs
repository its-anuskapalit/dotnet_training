using System;
class Program
{
    static void Main()
    {
        const double n = 30.48;
        Console.WriteLine("Enter feet Value: ");
        string? feet = Console.ReadLine();
        if(!double.TryParse(feet, out double f))
        {
            Console.WriteLine("Invalid Number");
            return;
        }
        if(f < 0)
        {
            Console.WriteLine("Input is sort");
        }
        double cm = f * n;
        Console.WriteLine(f +" Feet in Cm is " + cm);
    }
}