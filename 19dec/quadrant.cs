using System;
class quadrant
{
    public static void find()
    {
      Console.WriteLine("Enter the x coordinate");  
      int X=int.Parse(Console.ReadLine());  
      Console.WriteLine("Enter the y coordinate");  
      int Y=int.Parse(Console.ReadLine()); 
      if (X > 0 && Y > 0)
                Console.WriteLine("First Quadrant");
            else if (X < 0 && Y > 0)
                Console.WriteLine("Second Quadrant");
            else if (X < 0 && Y < 0)
                Console.WriteLine("Third Quadrant");
            else if (X > 0 && Y < 0)
                Console.WriteLine("Fourth Quadrant");
            else
                Console.WriteLine("On Axis");
        }
    }
