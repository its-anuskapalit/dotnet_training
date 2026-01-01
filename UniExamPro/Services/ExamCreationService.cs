using UniExamPro.Entities;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    // Service for managing Exam-related operations
    public class ExamCreationService
    {
        private readonly ExamRepository examRepo;
        // Constructor
        public ExamCreationService(ExamRepository repo)
        {
            examRepo = repo;
        }
        // Method to create a new exam
        public void CreateExam(int examId, int courseId, int sessionId)
        {
            examRepo.Add(new Exam(examId, courseId, sessionId));
        }
    }
}
