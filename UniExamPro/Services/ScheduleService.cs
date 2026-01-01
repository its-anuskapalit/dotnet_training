using System;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    // Service for managing Schedule-related operations
    public class ScheduleService
    {
        private readonly ExamRepository examRepo;
        // Constructor
        public ScheduleService(ExamRepository repo)
        {
            examRepo = repo;
        }
        // Method to view all scheduled exams
        public void ViewAllExams()
        {
            foreach (var exam in examRepo.GetAll())
            {
                exam.DisplayInfo();
            }
        }
    }
}
