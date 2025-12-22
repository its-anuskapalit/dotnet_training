using System;
// CONSTRUCTOR OVERLOADING PROGRAM
namespace Oops
{
public class MainConstructor
{
    public static void Main()
    {
        Visitor v1 = new Visitor();
        Visitor v2 = new Visitor(1);
        Visitor v3 = new Visitor(2, "Anuska");
        Visitor v4 = new Visitor(3, "Anuska", "Project Discussion");
            //try
            // {
            //     Visitor v5 = new Visitor(2, "idiot");
            // }
            // catch(Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }   

        // Visitor v6 = new Visitor(50,5); 
        // Console.WriteLine(v6.Result);  
    }
}
}