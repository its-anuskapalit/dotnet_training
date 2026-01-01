using System;
using UniExamPro.Repositories;
namespace UniExamPro.Integrations
{
    // Class to map students to courses
    public class StudentCourseMapper
    {
        private readonly StudentRepository studentRepo;
        private readonly CourseRepository courseRepo;
        // Constructor
        public StudentCourseMapper(StudentRepository sRepo, CourseRepository cRepo)
        {
            studentRepo = sRepo;
            courseRepo = cRepo;
        }
        // Method to enroll student to course
        public void EnrollStudentToCourse(int studentId, int courseId)
        {
            var student = studentRepo.GetById(studentId);
            var course = courseRepo.GetById(courseId);
            // Validate department match
            if (student == null || course == null)
                throw new Exception("Student or Course not found");
            // Ensure student and course belong to the same department
            if (student.DepartmentId != course.DepartmentId)
                throw new Exception("Student and Course Department mismatch");
            // Enroll student to course
            student.AddCourse(courseId);
        }
    }
}
