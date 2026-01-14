using System;
using Students;
using Generics;
namespace Students
{
    public class Student
    {
        public int Id { get; set; }
    }
    public class UGStudent : Student
    {
        public int Semester { get; set; }
    }
    public class PGStudent : Student
    {
        public string? Specialization { get; set; }
    }
}
namespace Generics
{
    public class MyGlobalType<T> where T : Student
    {
        public string PrintStudentType(T obj)
        {
            return obj.GetType().ToString();
        }
    }
}

namespace ApplicationLayer
{
    public class Program
    {
        public static void Main()
        {
            MyGlobalType<UGStudent> ugHandler = new MyGlobalType<UGStudent>();
            UGStudent ug = new UGStudent { Id = 1, Semester = 6 };
            Console.WriteLine(ugHandler.PrintStudentType(ug));

            MyGlobalType<PGStudent> pgHandler = new MyGlobalType<PGStudent>();
            PGStudent pg = new PGStudent { Id = 2, Specialization = "Data Science" };
            Console.WriteLine(pgHandler.PrintStudentType(pg));
        }
    }
}
