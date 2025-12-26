using ExamManagement;
// Main program to demonstrate the exam management system
class Program
{
    //main method
    static void Main()
    {
        // Create Department
        Department cs = new Department { Name = "Computer Science" };

        // Create Semester and Subjects
        Semester sem1 = new Semester { SemesterNo = 1 };

        Subject sub1 = new Subject { SubjectName = "C#" };
        Subject sub2 = new Subject { SubjectName = "DBMS" };

        sem1.Subjects.Add(sub1);
        sem1.Subjects.Add(sub2);
        cs.Semesters.Add(sem1);

        // Create Examiner
        Examiner ex = new Examiner { Id = 1, Name = "Dr. Sharma" };

        sub1.Exam = new Examination { Subject = sub1, Examiner = ex };
        sub2.Exam = new Examination { Subject = sub2, Examiner = ex };

        // Create Students and Results
        string[] names = { "Aarav", "Ishita", "Rohan", "Neha", "Arjun", "Priya", "Kunal", "Simran", "Rahul", "Sneha" };
        Random rnd = new Random();

        // Adding 10 students
        for (int i = 0; i < 10; i++)
        {
            Student s = new Student { StudentId = i + 1, Name = names[i], Semester = sem1 };

            Result r1 = new Result { Subject = sub1 };
            Result r2 = new Result { Subject = sub2 };

            ex.Evaluate(r1, rnd.Next(50, 95));
            ex.Evaluate(r2, rnd.Next(50, 95));

            s.Results.Add(r1);
            s.Results.Add(r2);

            cs.Students.Add(s);
        }
        // Display Department Details
        Console.WriteLine("Department: " + cs.Name);

        foreach (var s in cs.Students)
        {
            Console.WriteLine("\nStudent: " + s.Name);
            foreach (var r in s.Results)
            {
                Console.WriteLine(r.Subject.SubjectName + " Marks: " + r.Marks + " Grade: " + r.Grade);
            }
        }
    }
}
