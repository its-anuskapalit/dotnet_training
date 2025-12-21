// using System;
// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter your name : ");
//         String a = Console.ReadLine();
//         Console.WriteLine("Hello: " + a+ "!");
//     }
// }



// //Pime numbers
// using System;
// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter number: ");
//         int a = int.Parse(Console.ReadLine());
//         for (int i = 1; i < a; i += 2)
//         {
//             int c = 0;
//             for (int j = 2; j * j <= i; j++)
//             {
//                 if (i % j == 0)
//                 {
//                     c++;
//                     break;
//                 }
//             }

//             if (c == 0)
//             {
//                 Console.WriteLine(i);
//             }
//         }
//     }
// }


// using System;
// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter age: ");
//         String a=Console.ReadLine();
//         if(int.TryParse(a,out int age))
//         {
//             bool isAdult = age>=18;
//             Console.WriteLine("Adult ? "+ isAdult);
//         }
//         else
//         {
//             Console.WriteLine("Invalid age.Please enter a whole number. ");
//         }
//     }
// }


using System;
class Program{
    static void Main()
    {
        Console.WriteLine("Feet: ");
        int a=int.Parse(Console.ReadLine());
        double c=30.48*a;
        Console.WriteLine("Centimeters: "+ c);


    }
}
