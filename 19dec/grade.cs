using System;

class GradeDescription
{
    public static void Run()
    {
        try
        {
            Console.Write("Enter Grade: ");
            char Grade = char.ToUpper(Console.ReadLine()[0]);

            switch (Grade)
            {
                case 'E': Console.WriteLine("Excellent"); break;
                case 'V': Console.WriteLine("Very Good"); break;
                case 'G': Console.WriteLine("Good"); break;
                case 'A': Console.WriteLine("Average"); break;
                case 'F': Console.WriteLine("Fail"); break;
                default: Console.WriteLine("Invalid Grade"); break;
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
