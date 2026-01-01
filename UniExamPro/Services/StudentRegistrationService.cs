using UniExamPro.Entities;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    // Service for managing Student-related operations
    public class StudentRegistrationService
    {
        // Repository for accessing student data
        private readonly StudentRepository studentRepo;
        // Constructor
        public StudentRegistrationService(StudentRepository repo)
        {
            studentRepo = repo;
        }
        // Method to register a new student
        public void RegisterStudent(int id, string name, int deptId)
        {
            studentRepo.Add(new Student(id, name, deptId));
        }
    }
}
