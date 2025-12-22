using System;
//Math ≥ 65, Phys ≥ 55, Chem ≥ 50 AND (Total ≥ 180 OR Math+Phys ≥ 140).
class Admission
{
    public static void Eligibility()
    {
        // Basic input parsing 
        Console.WriteLine("Enter the score of maths");
        String? mathS=Console.ReadLine();
        Console.WriteLine("Enter the score of chemistry");
        String? chemS=Console.ReadLine();
        Console.WriteLine("Enter the score of physics");
        String? pyS=Console.ReadLine();

        // Validate input and check eligibility
        if (int.TryParse(mathS, out int mathNum)&&int.TryParse(pyS, out int phyNum)&&int.TryParse(chemS, out int chemNum))
        {
            if((mathNum+chemNum+phyNum)>181 || ((mathNum + phyNum) > 140))
            {
                Console.WriteLine("The student passed");
            }
            else if(mathNum >66 && phyNum > 56 && chemNum > 51)
            {
                Console.WriteLine("The student passed");
            }
            else
            {
                Console.WriteLine("The student not passed");
            }
        }
        // invalid input handling
        else
        {
            Console.WriteLine("Enter valid scores");
        }
    }
}