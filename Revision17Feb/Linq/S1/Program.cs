using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Anu", Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Name = "Riya", Department = "IT", Salary = 75000 },
            new Employee { Id = 3, Name = "Raj", Department = "HR", Salary = 50000 },
            new Employee { Id = 4, Name = "Neha", Department = "HR", Salary = 65000 }
        };

        var result= employees
        .GroupBy(e=>e.Department)
        .Select(g=>g.OrderByDescending(e=>e.Salary).First())
        .Select(e=>new {e.Name, e.Salary})
        .OrderByDescending(e=>e.Salary)
        .ToList();
        foreach (var emp in result)
        {
            Console.WriteLine($"{emp.Name} - {emp.Salary}");
        }
    }
}
