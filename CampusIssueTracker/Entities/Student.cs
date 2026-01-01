using CampusIssueTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusIssueTracker.Entities
{
    // Student class inheriting from Person
    public class Student: Person
    {
        // Department ID the student belongs to
        public int DepartmentId { get; private set; }
        public Student(int id, string name,int departmentId) : base(id,name)
            {
                        DepartmentId = departmentId;
        }
        // Override method to display student information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Student ID: {Id}, Name: {Name}, Department ID: {DepartmentId}");
        }
    }
}
