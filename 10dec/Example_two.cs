using System;
namespace Enums{
    public enum Semesters
{
    FIRST_SEMESTER = 1,
    SECOND_SEMESTER = 2
}
public enum Subject
{
    Maths = 11,
    Python = 12,
    Chemistry = 21,
    Biology = 22,
    Physics=23
}
class Program
{
    static void Main(string[] args)
    {
        // var semesterSubjects = new (Semesters, Subject[])[]
        // {
        //     (Semesters.FIRST_SEMESTER, new Subject[] { Subject.Maths, Subject.Python }),
        //     (Semesters.SECOND_SEMESTER, new Subject[] { Subject.Chemistry, Subject.Biology, Subject.Physics })
        // };
        // foreach (var item in semesterSubjects)
        // {
        //     Console.WriteLine("Semester: " + item.Item1);
        //     foreach (var subject in item.Item2)
        //     {
        //         Console.WriteLine("  Subject: " + subject + " (Code: " + (int)subject + ")");
        //     }
        // }
    }
}
}