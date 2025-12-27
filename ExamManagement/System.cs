using System;
using System.Collections.Generic;

namespace Oops
{
    public class HOD
    {
        public string Name { get; set; }

        public void ScheduleExam(Semester semester, Course course, ExamSchedule schedule)
        {
            Exam exam = new Exam
            {
                ExamId = new Random().Next(1000, 9999),
                Course = course,
                ExamSchedule = schedule
            };
            semester.Exams.Add(exam);
        }

        public void AssignExaminer(Exam exam, Examiner examiner)
        {
            exam.Examiners.Add(examiner);
            examiner.AssignedExams.Add(exam);
        }
    }

    public class Semester
    {
        public int SemId { get; set; }
        public List<Course> Courses { get; set; } = new();
        public List<Student> Students { get; set; } = new();
        public List<Exam> Exams { get; set; } = new();
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
    }

    public class Examiner
    {
        public int ExaminerId { get; set; }
        public string Name { get; set; }
        public List<Exam> AssignedExams { get; set; } = new();
    }

    public class Exam
    {
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public ExamSchedule ExamSchedule { get; set; }
        public List<Examiner> Examiners { get; set; } = new();
    }

    public class ExamSchedule
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Hall { get; set; }
    }

    class Program
    {
        static void Main()
        {
            HOD hod = new() { Name = "Dr. Roy" };

            Semester sem3 = new() { SemId = 3 };

            sem3.Students.AddRange(new[]
            {
                new Student{ RollNo=1, Name="Anuska"},
                new Student{ RollNo=2, Name="Riya"},
                new Student{ RollNo=3, Name="Neha"}
            });

            sem3.Courses.AddRange(new[]
            {
                new Course{ CourseId=101, Name="OOPS"},
                new Course{ CourseId=102, Name="DBMS"},
                new Course{ CourseId=103, Name="CN"}
            });

            Examiner e1 = new() { ExaminerId = 1, Name = "Prof. Sen" };
            Examiner e2 = new() { ExaminerId = 2, Name = "Prof. Sharma" };

            foreach (var course in sem3.Courses)
            {
                hod.ScheduleExam(sem3, course, new ExamSchedule
                {
                    Date = DateTime.Now.AddDays(course.CourseId % 3 + 1),
                    Time = "10:00 AM - 1:00 PM",
                    Hall = "Block B"
                });
            }

            hod.AssignExaminer(sem3.Exams[0], e1);
            hod.AssignExaminer(sem3.Exams[1], e2);
            hod.AssignExaminer(sem3.Exams[2], e1);

            Console.WriteLine("\n------ STUDENT LIST ------");
            foreach (var s in sem3.Students)
                Console.WriteLine($"{s.RollNo}  {s.Name}");

            Console.WriteLine("\n------ EXAM SCHEDULE ------");
            foreach (var exam in sem3.Exams)
            {
                Console.WriteLine($"\nSubject: {exam.Course.Name}");
                Console.WriteLine($"Date: {exam.ExamSchedule.Date.ToShortDateString()}");
                Console.WriteLine($"Time: {exam.ExamSchedule.Time}");
                Console.WriteLine($"Hall: {exam.ExamSchedule.Hall}");
                Console.WriteLine("Examiners:");
                foreach (var ex in exam.Examiners)
                    Console.WriteLine($"   - {ex.Name}");
            }
        }
    }
}
