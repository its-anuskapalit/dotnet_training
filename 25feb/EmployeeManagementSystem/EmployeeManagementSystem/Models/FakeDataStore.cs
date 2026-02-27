using System.Collections.Generic;
using System.Linq;

public static class FakeDataStore
{
    public static List<Department> Departments { get; set; } = new List<Department>
    {
        new Department { DepartmentId = 1, Name = "HR" },
        new Department { DepartmentId = 2, Name = "IT" },
        new Department { DepartmentId = 3, Name = "Finance" }
    };

    public static List<Employee> Employees { get; set; } = new List<Employee>();

    public static int EmployeeCounter = 1;
    public static int DepartmentCounter = 4;
}