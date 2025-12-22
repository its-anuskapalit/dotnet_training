using System;

class ValidDate
{
    public static void Run()
    {
        try
        {
            Console.Write("Day: ");
            int Day = int.Parse(Console.ReadLine());

            Console.Write("Month: ");
            int Month = int.Parse(Console.ReadLine());

            Console.Write("Year: ");
            int Year = int.Parse(Console.ReadLine());

            DateTime Date = new DateTime(Year, Month, Day);
            Console.WriteLine("Valid Date");
        }
        catch
        {
            Console.WriteLine("Invalid Date");
        }
    }
}
