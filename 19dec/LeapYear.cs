using System;
// LEAP YEAR CHECKER PROGRAM
class LeapYear
{
    public static void Checker()
    {
        //input parse
        Console.WriteLine("Enter the year: ");
        String? year=Console.ReadLine();
        bool check=true;
        //check leap year
        if (int.TryParse(year, out int yearNum))
        {
            if( (yearNum%400 ==0) || (yearNum % 4== 0 && yearNum%100!=0))
            {
                Console.WriteLine(yearNum+" is a leap year");
            }
            else
            //  not a leap year
            {
                Console.WriteLine(yearNum+" is not a leap year");
            }
        }
    }
}