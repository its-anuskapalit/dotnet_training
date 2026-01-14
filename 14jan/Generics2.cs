using System;
using System.Collections.Generic;
using Employees;
using Generics;

namespace Employees
{
    public class Employee
    {
        public int Id { get; set; }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }
    }

    public class PartTimeEmployee : Employee
    {
        public int HourlyRate { get; set; }
    }
}

namespace Generics
{
    public class EmployeeRepository<T> where T : Employee
    {
        private List<T> employees = new List<T>();

        public void Add(T employee)
        {
            employees.Add(employee);
        }

        public List<T> GetAll()
        {
            return employees;
        }
    }

    public class EmployeeBox<T, K> where T : Employee
    {
        public T EmployeeData { get; set; }
        public K MetaData { get; set; }

        public EmployeeBox(T employee, K meta)
        {
            EmployeeData = employee;
            MetaData = meta;
        }
        public int GetAll(T t, K k)
        {
            return t.Id ; 
        }

        public string GetBoxType()
        {
            return EmployeeData.GetType().ToString() + " | MetaType: " + typeof(K).ToString();
        }
    }
}

namespace ApplicationLayer
{
    public class Program2
    {
        public static void Main()
        {
            EmployeeRepository<FullTimeEmployee> fullRepo = new EmployeeRepository<FullTimeEmployee>();
            fullRepo.Add(new FullTimeEmployee { Id = 1, Salary = 50000 });

            EmployeeRepository<PartTimeEmployee> partRepo = new EmployeeRepository<PartTimeEmployee>();
            partRepo.Add(new PartTimeEmployee { Id = 2, HourlyRate = 700 });

            EmployeeBox<FullTimeEmployee, string> fullBox =
                new EmployeeBox<FullTimeEmployee, string>(
                    new FullTimeEmployee { Id = 10, Salary = 80000 },
                    "HR Department");

            EmployeeBox<PartTimeEmployee, int> partBox =
                new EmployeeBox<PartTimeEmployee, int>(
                    new PartTimeEmployee { Id = 20, HourlyRate = 900 },
                    3);

            Console.WriteLine(fullBox.GetBoxType());
            Console.WriteLine(partBox.GetBoxType());
        }
    }
}
