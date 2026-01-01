using System.Collections.Generic;
using System.Linq;
using UniExamPro.Entities;
using UniExamPro.Interfaces;
namespace UniExamPro.Repositories
{
    // Repository for managing Student entities
    public class StudentRepository : IRepository<Student>
    {
        // Internal storage for students
        private readonly List<Student> students = new List<Student>();
        // Adds a new student to the repository
        public void Add(Student student)
        {
            students.Add(student);
        }
        // Retrieves a student by their unique identifier
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        // Retrieves all students from the repository
        public List<Student> GetAll()
        {
            return students;
        }
    }
}
