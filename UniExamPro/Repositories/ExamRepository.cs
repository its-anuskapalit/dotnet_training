using System.Collections.Generic;
using System.Linq;
using UniExamPro.Entities;
using UniExamPro.Interfaces;
namespace UniExamPro.Repositories
{
    // Repository for managing Exam entities
    public class ExamRepository : IRepository<Exam>
    {
        private readonly List<Exam> exams = new List<Exam>();
        // Adds a new exam to the repository
        public void Add(Exam exam)
        {
            exams.Add(exam);
        }
        // Retrieves an exam by its ID
        public Exam GetById(int id)
        {
            return exams.FirstOrDefault(e => e.ExamId == id);
        }
        //  Retrieves all exams from the repository
        public List<Exam> GetAll()
        {
            return exams;
        }
    }
}
