using UniExamPro.Entities;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    // Service for managing Department-related operations
    public class DepartmentService
    {
        // Repository for accessing department data
        private readonly DepartmentRepository departmentRepo;
        //  Constructor
        public DepartmentService(DepartmentRepository repo)
        {
            departmentRepo = repo;
        }
        //  Method to create a new department
        public void CreateDepartment(int id, string name)
        {
            departmentRepo.Add(new Department(id, name));
        }
    }
}
