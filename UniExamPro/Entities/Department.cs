using System;
namespace UniExamPro.Entities
{
    // Department entity class
    public class Department
    {
        public int DepartmentId { get; private set; }
        public string Name { get; private set; }
        // Constructor
        public Department(int departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }
        // Method to display department info
        public void DisplayInfo()
        {
            Console.WriteLine($"Department Id: {DepartmentId}, Name: {Name}");
        }
    }
}
