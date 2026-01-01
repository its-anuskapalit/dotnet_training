using System;
using UniExamPro.Repositories;
namespace UniExamPro.Integrations
{
    // Class to allocate examiners to exams
    public class ExaminerExamAllocator
    {
        private readonly ExaminerRepository examinerRepo;
        private readonly ExamRepository examRepo;
        // Constructor
        public ExaminerExamAllocator(ExaminerRepository eRepo, ExamRepository exRepo)
        {
            examinerRepo = eRepo;
            examRepo = exRepo;
        }
        // Method to allocate examiner to exam
        public void AllocateExaminer(int examinerId, int examId)
        {
            // Fetch examiner and exam
            var examiner = examinerRepo.GetById(examinerId);
            var exam = examRepo.GetById(examId);
            // Validate existence
            if (examiner == null || exam == null)
                throw new Exception("Examiner or Exam not found");
            // Allocate examiner to exam
            exam.AllocateExaminer(examinerId);
            examiner.AssignExam(examId);
        }
    }
}
