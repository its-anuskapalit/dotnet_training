using System;
using System.Collections.Generic;
using System.Text;
using UniExamPro.Core;
namespace UniExamPro.Entities
{
    // Examiner entity class inheriting from BasePerson
    public class Examiner : BasePerson
    {
        //properties
        public int DepartmentId { get; private set; }
        public List<int> AssignedExamIds{ get; private set; }
        public Examiner(int id, string name, int departmentId) : base(id, name)
        {
            DepartmentId = departmentId;
            AssignedExamIds = new List<int>();
        }
        //method to assign exam
        public void AssignExam(int examId)
        {
            if (!AssignedExamIds.Contains(examId))
                AssignedExamIds.Add(examId);
        }
        //override method to display examiner info
        public override void DisplayInfo()
        {
            Console.WriteLine($"Examiner Id: {Id}, Name: {Name}, DeptId: {DepartmentId}");
        }
    }
}
