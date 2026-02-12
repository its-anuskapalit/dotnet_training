using System;
namespace Q6
{
    public class Person
    {
        public string Name;
        public int Age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public class Student : Person
    {
        public int RollNo;
        public int Marks;

        public Student(int roll, int marks, string name, int age): base(name, age)
        {
            RollNo = roll;
            Marks = marks;
        }
        public void PrintResult()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine(Marks < 35 ? "Result: Fail" : "Result: Pass");
        }
    }
    class Program
    {
        static void Main()
        {
            Student s = new Student(101, 78, "Anuska", 22);
            s.PrintResult();
        }
    }
}
