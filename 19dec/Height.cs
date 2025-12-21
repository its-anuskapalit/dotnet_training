using System;
///Height Category: Accept height in cm. If < 150 (Dwarf), 150-165 (Average), 165-190 (Tall), >190 (Abnormal).
class Height
{
    public static void check()
    {
        //input parse
        try{
        Console.WriteLine("Enter the hight as cm: ");
        string? heightInput=Console.ReadLine();
        if(int.TryParse(heightInput, out int heightI))
        {
            if(heightI < 150)
            {
                Console.WriteLine("Dwarf");
            }
            else if (heightI > 150 && heightI <= 165)
            {
                Console.WriteLine("Average");
            }
            else if(heightI > 165 && heightI <= 190)
            {
                Console.WriteLine("Tall");
            }
            else if (heightI >190)
            {
                Console.WriteLine("Adnormal");
            }
        }
        else
        {
            Console.WriteLine("Enter a valid interger input for height");
        }
        }
        catch(Exception Ex)
        {
            Console.WriteLine("Invalid input" +Ex.Message);
        }
    }
}