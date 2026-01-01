using UniExamPro.Entities;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    public class ExaminerRegistrationService
    {
        // Repository for accessing examiner data
        private readonly ExaminerRepository examinerRepo;
        // Constructor
        public ExaminerRegistrationService(ExaminerRepository repo)
        {
            examinerRepo = repo;
        }
        // Method to register a new examiner
        public void RegisterExaminer(int id, string name, int deptId)
        {
            examinerRepo.Add(new Examiner(id, name, deptId));
        }
    }
}
