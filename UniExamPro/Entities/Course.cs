using System;
namespace UniExamPro.Entities
{
    // Course entity class
    public class Course
    {
        //properties
        public int CourseId { get; private set; }
        public string Name { get; private set; }
        public int DepartmentId { get; private set; }
        //constructor
        public Course(int courseId, string name, int departmentId)
        {
            CourseId = courseId;
            Name = name;
            DepartmentId = departmentId;
        }
        //method to display course info
        public void DisplayInfo()
        {
            Console.WriteLine($"Course Id: {CourseId}, Name: {Name}, DeptId: {DepartmentId}");
        }
    }
}
