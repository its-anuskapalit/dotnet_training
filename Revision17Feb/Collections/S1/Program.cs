using System;
class Student
{
    public int Id{get;set;}
    public string Name{get;set;}
}
class Program
{
    static void Main()
    {
        List<Student> students=new List<Student>();
        students.Add(new Student{Id=1, Name="Anuska"});
        students.Add(new Student{Id=2,Name="Sachin"});

        foreach(var s in students)
        {
            Console.WriteLine($"ID is {s.Id} and Name is {s.Name}");
        }
    }
}