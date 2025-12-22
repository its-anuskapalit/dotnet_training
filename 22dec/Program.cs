using System;
// CONSTRUCTOR OVERLOADING PROGRAM
using Oops;
class Program
{
    public static void Main()
    {
        Visitor v1 = new Visitor();
        Visitor v2 = new Visitor(1);
        Visitor v3 = new Visitor(2, "Anuska");
        Visitor v4 = new Visitor(3, "Anuska", "Project Discussion");
        
    }
}