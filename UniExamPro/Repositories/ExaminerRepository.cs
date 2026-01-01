using System.Collections.Generic;
using System.Linq;
using UniExamPro.Entities;
using UniExamPro.Interfaces;
namespace UniExamPro.Repositories
{
    // Repository for managing Examiner entities
    public class ExaminerRepository : IRepository<Examiner>
    {
        private readonly List<Examiner> examiners = new List<Examiner>();
        //  Adds a new examiner to the repository
        public void Add(Examiner examiner)
        {
            examiners.Add(examiner);
        }
        // Retrieves an examiner by their unique identifier
        public Examiner GetById(int id)
        {
            return examiners.FirstOrDefault(e => e.Id == id);
        }
        // Retrieves all examiners in the repository
        public List<Examiner> GetAll()
        {
            return examiners;
        }
    }
}
