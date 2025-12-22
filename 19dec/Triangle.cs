using System;
//  TRIANGLE TYPE PROGRAM
class TriangleType
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Side A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Side B: ");
            int B = int.Parse(Console.ReadLine());

            Console.Write("Side C: ");
            int C = int.Parse(Console.ReadLine());

            if (A == B && B == C)
                Console.WriteLine("Equilateral Triangle");
            else if (A == B || B == C || A == C)
                Console.WriteLine("Isosceles Triangle");
            else
                Console.WriteLine("Scalene Triangle");
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
