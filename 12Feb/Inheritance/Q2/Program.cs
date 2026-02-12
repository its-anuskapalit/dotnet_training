using System;
class Person
{
    int Id=1;
    string name= "Anuska";
    public void GetDetails()
    {
        Console.WriteLine($"The id: {Id} \nName: {name}");
    }
}
class Student : Person
{
    int Id=2;
    string name= "Polly";
    public void GetDetails()
    {
        Console.WriteLine($"The id: {Id} \nName: {name}");
    }
}
class Program
{
    static void Main()
    {
        Student student=new Student();
        student.GetDetails();
    }
}