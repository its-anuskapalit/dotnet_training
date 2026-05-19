// using System;
// class Student
// {
//     public int Id{get;set;}
//     public string Name{get;set;}
//     public Student(int id,string name)
//     {
//         Id=id;
//         Name=name;
//     }
// }
// class StudentRepository
// {
//     private Dictionary<int,Student> _students=new Dictionary<int, Student>();
//     public void Add(Student student)
//     {
//         if (!_students.ContainsKey(student.Id))
//         {
//             _students.Add(student.Id,student);
//         }
//         else
//         {
//             Console.WriteLine("Student ID already exists.");
//         }
//     }
//     public Student GetStudent(int id)
//     {
//         if (_students.ContainsKey(id))
//         {
//             return _students[id];
//         }
//         return null;
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         StudentRepository repo=new StudentRepository();
//         repo.Add(new Student(1,"Anuska"));
//         repo.Add(new Student(2,"Sachin"));
//         var student=repo.GetStudent(1);
//         Console.WriteLine($"{student.Id} {student.Name}");
//     }
// }

using System;
using System.Collections.Generic;

class MarksRepository
{
    private Dictionary<int, List<int>> _studentMarks = new Dictionary<int, List<int>>();

    public void AddMarks(int studentId, int mark)
    {
        if (!_studentMarks.ContainsKey(studentId))
        {
            _studentMarks[studentId] = new List<int>();
        }

        _studentMarks[studentId].Add(mark);
    }

    public List<int> GetMarks(int studentId)
    {
        if (_studentMarks.ContainsKey(studentId))
        {
            return _studentMarks[studentId];
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        MarksRepository repo = new MarksRepository();

        repo.AddMarks(1, 85);
        repo.AddMarks(1, 90);
        repo.AddMarks(1, 78);

        repo.AddMarks(2, 88);
        repo.AddMarks(2, 76);

        var marks = repo.GetMarks(1);

        if (marks != null)
        {
            Console.WriteLine("Marks of Student 1:");
            foreach (var m in marks)
            {
                Console.WriteLine(m);
            }
        }
    }
}
