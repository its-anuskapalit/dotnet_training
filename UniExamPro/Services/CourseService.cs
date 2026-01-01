using UniExamPro.Entities;
using UniExamPro.Repositories;
namespace UniExamPro.Services
{
    // Service for managing Course-related operations
    public class CourseService
    {
        //  Repository for accessing course data
        private readonly CourseRepository courseRepo;
        //  Constructor
        public CourseService(CourseRepository repo)
        {
            courseRepo = repo;
        }
        //  Method to create a new course
        public void CreateCourse(int id, string name, int deptId)
        {
            courseRepo.Add(new Course(id, name, deptId));
        }
    }
}
