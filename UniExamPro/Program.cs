using System;
using UniExamPro.Repositories;
using UniExamPro.Services;
using UniExamPro.Integrations;
namespace UniExamPro
{
    // Main program class
    class Program
    {
        static void Main()
        {
            //  Initialize repositories
            var studentRepo = new StudentRepository();
            var examinerRepo = new ExaminerRepository();
            var deptRepo = new DepartmentRepository();
            var courseRepo = new CourseRepository();
            var examRepo = new ExamRepository();
            // Initialize services
            var studentService = new StudentRegistrationService(studentRepo);
            var examinerService = new ExaminerRegistrationService(examinerRepo);
            var deptService = new DepartmentService(deptRepo);
            var courseService = new CourseService(courseRepo);
            var examService = new ExamCreationService(examRepo);
            var scheduleService = new ScheduleService(examRepo);
            // Initialize integrations
            var studentCourseMapper = new StudentCourseMapper(studentRepo, courseRepo);
            var examinerAllocator = new ExaminerExamAllocator(examinerRepo, examRepo);

            // Main loop
            while (true)
            {
                // Display menu
                Console.WriteLine("\n===== HOD Examination Management Panel =====");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Register Student");
                Console.WriteLine("4. Register Examiner");
                Console.WriteLine("5. Create Exam");
                Console.WriteLine("6. Enroll Student To Course");
                Console.WriteLine("7. Allocate Examiner To Exam");
                Console.WriteLine("8. View Exam Schedule");
                Console.WriteLine("9. Exit");
                Console.Write("Choose: ");

                // Get user choice
                int choice = int.Parse(Console.ReadLine());
                // Handle user choice
                switch (choice)
                {
                    case 1:
                        Console.Write("Dept Id: ");
                        deptService.CreateDepartment(int.Parse(Console.ReadLine()), Console.ReadLine());
                        break;

                    case 2:
                        Console.Write("Course Id: ");
                        int cid = int.Parse(Console.ReadLine());
                        Console.Write("Course Name: ");
                        string cname = Console.ReadLine();
                        Console.Write("Dept Id: ");
                        courseService.CreateCourse(cid, cname, int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Student Id: ");
                        int sid = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string sname = Console.ReadLine();
                        Console.Write("Dept Id: ");
                        studentService.RegisterStudent(sid, sname, int.Parse(Console.ReadLine()));
                        break;

                    case 4:
                        Console.Write("Examiner Id: ");
                        int eid = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string ename = Console.ReadLine();
                        Console.Write("Dept Id: ");
                        examinerService.RegisterExaminer(eid, ename, int.Parse(Console.ReadLine()));
                        break;

                    case 5:
                        Console.Write("Exam Id: ");
                        int exid = int.Parse(Console.ReadLine());
                        Console.Write("Course Id: ");
                        int crid = int.Parse(Console.ReadLine());
                        Console.Write("Session Id: ");
                        examService.CreateExam(exid, crid, int.Parse(Console.ReadLine()));
                        break;

                    case 6:
                        Console.Write("Student Id: ");
                        int stid = int.Parse(Console.ReadLine());
                        Console.Write("Course Id: ");
                        studentCourseMapper.EnrollStudentToCourse(stid, int.Parse(Console.ReadLine()));
                        break;

                    case 7:
                        Console.Write("Examiner Id: ");
                        int exmr = int.Parse(Console.ReadLine());
                        Console.Write("Exam Id: ");
                        examinerAllocator.AllocateExaminer(exmr, int.Parse(Console.ReadLine()));
                        break;

                    case 8:
                        scheduleService.ViewAllExams();
                        break;

                    case 9:
                        return;
                }
            }
        }
    }
}
