using System;
using UniExamPro.Repositories;
namespace UniExamPro.Integrations
{
    // Class to schedule students for exams
    public class StudentExamScheduler
    {
        private readonly StudentRepository studentRepo;
        private readonly ExamRepository examRepo;
        // Constructor
        public StudentExamScheduler(StudentRepository sRepo, ExamRepository eRepo)
        {
            studentRepo = sRepo;
            examRepo = eRepo;
        }
        // Method to validate student for an exam
        public void ValidateStudentForExam(int studentId, int examId)
        {
            var student = studentRepo.GetById(studentId);
            var exam = examRepo.GetById(examId);
            // Check if student and exam exist
            if (student == null || exam == null)
                throw new Exception("Student or Exam not found");
            // Check if student is enrolled for the course
            if (!student.CourseIds.Contains(exam.CourseId))
                throw new Exception("Student is not enrolled for this course");
        }
    }
}
