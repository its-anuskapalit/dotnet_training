using System.Collections.Generic;
using System.Linq;
using UniExamPro.Entities;
using UniExamPro.Interfaces;

namespace UniExamPro.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly List<Department> departments = new List<Department>();

        public void Add(Department department)
        {
            departments.Add(department);
        }

        public Department GetById(int id)
        {
            return departments.FirstOrDefault(d => d.DepartmentId == id);
        }

        public List<Department> GetAll()
        {
            return departments;
        }
    }
}
