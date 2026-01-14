using System;

namespace PayrollSystem.Models
{
    public class FullTimeEmployee : Employee
    {
        public decimal BasicSalary { get; private set; }
        public decimal Bonus { get; private set; }
        public FullTimeEmployee(int id, string name, string department, DateTime joinDate,
                                string email, string phone, decimal basicSalary, decimal bonus)
            : base(id, name, department, joinDate, email, phone)
        {
            if (basicSalary <= 0) throw new ArgumentException("Basic salary must be greater than zero");
            if (bonus < 0) throw new ArgumentException("Bonus cannot be negative");

            BasicSalary = basicSalary;
            Bonus = bonus;
            EmployeeType = "Full Time";
        }

        public override decimal CalculateGrossSalary()
        {
            return BasicSalary + Bonus;
        }
        public override decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.12m;
        }
    }
}
