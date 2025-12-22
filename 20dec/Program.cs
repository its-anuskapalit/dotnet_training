using System;
using MyProject;
// STUDENT CLASS PROGRAM
class Program
{
    public static void main()
    {
        // Call the static Main method from Student class
        Student.Main();
        //OR
        // Create an instance of Student and call DisplayInfo
        Student s1 = new Student("Anuska", 21, 12206089);
        s1.DisplayInfo();
    }
}

//===========================================================
using System;
using MyProject;

class Program
{
    static void Main()
    {
        // Create Employee objects
        Employee[] employees =
        {
            new Employee(1, "Anuska", "SDE"),
            new Employee(2, "Riya", "Tester"),
            new Employee(3, "Aman", "Developer")
        };
        // Create Competition object
        Competition competition = new Competition(101, "Coding Competition");
        // Create Details object
        Details details = new Details(employees, competition);
        details.CollectScores();
        details.DisplayWinner();
    }
}
