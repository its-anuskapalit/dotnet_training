using System;
// class to Determine if a year is leap
class LeapYear
{
    public static void Checker()
    {
        //input parse
        Console.WriteLine("Enter the year: ");
        String? year=Console.ReadLine();
        bool check=true;
        if(int.TryParse(year, out int yearNum))
        {
            if( (yearNum%400 ==0) || (yearNum % 4== 0 && yearNum%100!=0))
            {
                Console.WriteLine(yearNum+" is a leap year");
            }
            else
            {
                Console.WriteLine(yearNum+" is not a leap year");
            }
        }
    }
}