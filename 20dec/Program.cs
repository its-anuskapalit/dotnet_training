// using System;
// using MyProject;
// class Program
// {
//     public static void main()
//     {
//         //Student.Main();
//         //                 OR
//         // Student s1 = new Student("Anuska", 21, 12206089);
//         // s1.DisplayInfo();       
//     }
// }

//===========================================================
using System;
using MyProject;

class Program
{
    static void Main()
    {
        Employee[] employees =
        {
            new Employee(1, "Anuska", "SDE"),
            new Employee(2, "Riya", "Tester"),
            new Employee(3, "Aman", "Developer")
        };

        Competition competition = new Competition(101, "Coding Competition");

        Details details = new Details(employees, competition);
        details.CollectScores();
        details.DisplayWinner();
    }
}
