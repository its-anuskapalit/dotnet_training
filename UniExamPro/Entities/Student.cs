using System;
using System.Collections.Generic;
using UniExamPro.Core;
namespace UniExamPro.Entities
{
    // Student entity class inheriting from BasePerson
    public class Student : BasePerson
    {
        public int DepartmentId { get; private set; }
        public List<int> CourseIds { get; private set; }
        // Constructor
        public Student(int id, string name, int departmentId) : base(id, name)
        {
            DepartmentId = departmentId;
            CourseIds = new List<int>();
        }
        // Method to add course
        public void AddCourse(int courseId)
        {
            if (!CourseIds.Contains(courseId))
                CourseIds.Add(courseId);
        }
        // Override method to display student info
        public override void DisplayInfo()
        {
            Console.WriteLine($"Student Id: {Id}, Name: {Name}, DeptId: {DepartmentId}");
        }
    }
}
