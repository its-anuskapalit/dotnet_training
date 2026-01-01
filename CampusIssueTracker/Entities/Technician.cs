using CampusIssueTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;
namespace CampusIssueTracker.Entities
{
    // Technician class inheriting from Person
    public class Technician: Person
    {
        // Nullable type: Technician may or may not be assigned to any department
        public int? AssignedDepartmentId { get; private set; }
        public Technician(int id,string name, int? deptId): base(id, name)
        {
            AssignedDepartmentId = deptId;
        }
        // Override method to display technician information
        public override void DisplayInfo()
        {
             Console.WriteLine($"Technician ID: {Id}, Name: {Name}, Assigned Department ID: {AssignedDepartmentId}");
        }
    }
}
