give me all full code 
using System;
using indexer;
//indexer usage
class Program
{
    public static void Main()
    {
        MyData obj = new MyData();
        obj[0] = "C";
        obj[1] = "C++";
        obj[2] = "C#";
        Console.WriteLine("First: " + obj[0]);
        Console.WriteLine("Second: " + obj[1]);
        Console.WriteLine("Third: " + obj[2]);
    }
}

//=============================================================================================================

 using System;
 using indexer;
// Student class with indexer
 class Program
{
    static void Main()
    {
        Student s = new Student();
        s.Rno = 101;
        s.Name = "Anuska";
        s.Address = "kolkata";
        s[0] = "C# Programming";
        s[1] = "Data Structures";
        s[2] = "Machine Learning";
        s[3] = "AI Concepts";
        Console.WriteLine("Roll No: " + s.Rno);
        Console.WriteLine("Name: " + s.Name);
        Console.WriteLine("Address: " + s.Address);

        Console.WriteLine("Books Issued:");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Book " + (i + 1) + ": " + s[i]);
        }
        Console.WriteLine("=============================================================================================================");

        Student s2 = new Student();
        s2.Rno = 202;
        s2.Name = "POlly";
        s2.Address = "Punjab";
        s2[0] = "C# Programming";
        s2[1] = "Data Structures";
        s2[2] = "Machine Learning";
        s2[3] = "AI Concepts";
        Console.WriteLine("Roll No: " + s2.Rno);
        Console.WriteLine("Name: " + s2.Name);
        Console.WriteLine("Address: " + s2.Address);

        Console.WriteLine("Books Issued:");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Book " + (i + 1) + ": " + s2[i]);
        }
    }
}

//=======================================================================================
 using System;
 using PartialClass;
//partial class usage
 public class Program
{
    public static void Main()
    {
        childParent c = new childParent();
        c.Id = 1;
        c.Id1 = 2;

        c.Display();
        c.Display1();
    }
}

//==============================================================================================
 using System;
 using StaticClass;
//static class usage
 public class Program
 {
     public static void Main()
     {
         int a=GeneralUses.GetNo();
         int b=GeneralUses.GetNo();
         Console.WriteLine(a);
         Console.WriteLine(b);
     }
 }
//===============================================================================================
namespace LearningCSharp
{
    //extension method usage
    public class Program
    {
        static void Main(string[] args)
        {

            string sent = "I am Fine.";
            int count = sent.WordCount();
            Console.WriteLine(count);
        }
    }

}