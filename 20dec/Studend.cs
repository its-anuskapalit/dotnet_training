using System;
namespace MyProject
{
public class Student //(System.object --> parent of all classes)
{
    //region Decalaration
    // Fields
    public int RollNumber;
    public string Name;
    public int Age;
    // Arrays for data
    public string[] Subjects = { "Maths", "Physics", "Chemistry" };
    public int[] MarkGain = { 56, 80, 95 };
    //End region Decalaration

    //region Constructor
    public Student(string name, int age, int roll)
    {
        Name = name;
        Age = age;
        RollNumber = roll; 
    }
    //endregion Constructor

    //region Method function
    // Method to display student details
    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name} (Roll: {RollNumber}, Age: {Age})");
        Console.WriteLine("Marks:");
        for (int i = 0; i < Subjects.Length; i++)
        {
            Console.WriteLine($"- {Subjects[i]}: {MarkGain[i]}");
        }
    }
    //endregion Method function
    
    // Main method to run the program
    public static void Main()
    {
        Student s1 = new Student("Anuska", 21, 12206089);
        s1.DisplayInfo();
    }
}
}