// using System;
// namespace Oops{
// public class Program : IPrint
// {
//         //implementing interface method
//         public void display()
//        {
//             Console.WriteLine("Hello world1");
//         }
//     public static void Main(string[] args)
//     {
//             // Creating object of interface
//         IPrint ob =new Program();
//         ob.display();

// }
// }
// }

//===================================================================================

using multi;
    class Program
    {
        public static void Main()
        {
        // Creating object of interface
        Visitor ob =new Visitor();
        VegEater a=new Visitor();
        NonVegEater b=new Visitor();
        //calling interface method
        a.display();
        b.display();

    }
    }
