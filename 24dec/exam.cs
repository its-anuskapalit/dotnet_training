using System;
namespace Model
{
    // Head of Department (HOD) class
    public class HOD
    {
        // HOD properties
        public int HodId { get; set; }
        public string Name { get; set; }
        // Schedule an exam for a course in a semester
        public void ScheduleExam(Semester semester, Course course, ExamSchedule schedule)
        {
            Exam exam = new Exam
            {
                ExamId = new Random().Next(1000, 9999),
                Course = course,
                ExamSchedule = schedule
            };
            semester.Exams.Add(exam);
            Console.WriteLine($"Exam scheduled for {course.Name}");
        }
        // Assign examiner to an exam
        public void AssignExaminer(Exam exam, Examiner examiner)
        {
            exam.AddExaminer(examiner);
            examiner.AssignExam(exam);
            Console.WriteLine($"{examiner.Name} assigned to {exam.Course.Name}");
        }
        // View exam schedules for a semester
        public void ViewSchedules(Semester semester)
        {
            foreach (var exam in semester.Exams)
                Console.WriteLine($"{exam.Course.Name} - {exam.ExamSchedule.ExamDate}");
        }
    }
    // Semester class
    // Represents a semester with courses and exams
    public class Semester
    {
        public int SemId { get; set; }
        public List<Course> Courses { get; set; } = new();
        public List<Exam> Exams { get; set; } = new();
    }
    // Course class
    // Represents a course
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
    // Exam class
    // Represents an exam
    public class Exam
    {
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public ExamSchedule ExamSchedule { get; set; }
        public List<Examiner> Examiners { get; set; } = new();
        public void AddExaminer(Examiner examiner)
        {
            Examiners.Add(examiner);
        }
    }
    // Examiner class
    // Represents an examiner
    public class Examiner
    {
        public int ExaminerId { get; set; }
        public string Name { get; set; }
        public List<Exam> AssignedExams { get; set; } = new();

        public void AssignExam(Exam exam)
        {
            AssignedExams.Add(exam);
        }
    }
    // ExamSchedule class
    // Represents the schedule of an exam
    public class ExamSchedule
    {
        public DateTime ExamDate { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public ExamHall ExamHall { get; set; }
    }
    // TimeSlot class
    // Represents a time slot for an exam
    public class TimeSlot
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    // ExamHall class
    // Represents an exam hall
    public class ExamHall
    {
        public int HallId { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
    // Program class to demonstrate functionality
    class Program
    {
        // Main method to demonstrate functionality
        static void Main()
        {
            // Create HOD
            HOD hod = new() { HodId = 1, Name = "Dr. Roy" };
            // Create Semester and Course
            Semester sem = new() { SemId = 3 };
            Course course = new() { CourseId = 101, Name = "OOPS" };
            // Add course to semester
            sem.Courses.Add(course);
            // Create Examiner and ExamSchedule
            Examiner examiner = new() { ExaminerId = 1, Name = "Prof. Sen" };
            ExamSchedule schedule = new()
            {
                ExamDate = DateTime.Now.AddDays(2),
                TimeSlot = new TimeSlot { StartTime = "10AM", EndTime = "1PM" },
                ExamHall = new ExamHall { HallId = 201, Capacity = 120, Location = "Block B" }
            };
            // Schedule exam and assign examiner
            hod.ScheduleExam(sem, course, schedule);
            hod.AssignExaminer(sem.Exams[0], examiner);
            hod.ViewSchedules(sem);
        }
    }
}
