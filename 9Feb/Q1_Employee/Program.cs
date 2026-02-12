using System;
using System.Text.RegularExpressions;
namespace Q1
{
    public class Employee
    {
        int Id;
        string Name;
        string Email;
        int Salary;
        public Employee(int id, string name, string email, int salary)
        {
            Id = id;
            Name = name;

            if (salary <= 0)
                Salary = 30000;
            else
                Salary = salary;

            if (IsValid(email))
                Email = email;
            else
                Email = "unknown@company.com";
        }

        bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        bool IsValid(string email)
        {
            return email.Contains('@');
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Email: {Email}, Salary: {Salary}");
        }
    }
    class Program
    {
        static void Main()
        {
            Employee e1 = new Employee(1, "Anuska", "anuska@gmail.com", 50000);
            Employee e2 = new Employee(2, "Sachin", "Sachingmail.com", -10000);
            Employee e3 = new Employee(3, "Devi", "devi@gmail", 0);

            e1.Display();
            e2.Display();
            e3.Display();
        }
    }
}


