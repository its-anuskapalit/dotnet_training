using System;
// VALID DATE PROGRAM
class ValidDate
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Day: ");
            int Day = int.Parse(Console.ReadLine());

            Console.Write("Month: ");
            int Month = int.Parse(Console.ReadLine());

            Console.Write("Year: ");
            int Year = int.Parse(Console.ReadLine());

            //validate date by attempting to create DateTime object
            DateTime Date = new DateTime(Year, Month, Day);
            Console.WriteLine("Valid Date");
        }
        //error
        catch
        {
            Console.WriteLine("Invalid Date");
        }
    }
}
