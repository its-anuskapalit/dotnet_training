using System.Collections.Generic;
using System.Linq;
using UniExamPro.Entities;
using UniExamPro.Interfaces;
namespace UniExamPro.Repositories
{
    // Repository for managing Course entities
    public class CourseRepository : IRepository<Course>
    {
        // In-memory list to store courses
        private readonly List<Course> courses = new List<Course>();
        // Adds a new course to the repository
        public void Add(Course course)
        {
            courses.Add(course);
        }
        // Retrieves a course by its ID
        public Course GetById(int id)
        {
            return courses.FirstOrDefault(c => c.CourseId == id);
        }
        public List<Course> GetAll()
        {
            return courses;
        }
    }
}
