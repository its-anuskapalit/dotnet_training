using System;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents a contract-based employee who is paid on an hourly basis.
    /// Calculates salary based on hourly rate, working days and standard daily hours.
    /// </summary>
    public class ContractEmployee : Employee
    {
        #region Properties

        // Rate paid for each working hour
        public decimal HourlyRate { get; private set; }

        // Number of working days in the month
        public int WorkingDays { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new ContractEmployee with validated payment parameters.
        /// </summary>
        public ContractEmployee(int id, string name, string department, DateTime joinDate,
                                string email, string phone, decimal hourlyRate, int workingDays)
            : base(id, name, department, joinDate, email, phone)
        {
            // Business rule: Hourly rate must be positive
            if (hourlyRate <= 0)
                throw new ArgumentException("Hourly rate must be greater than zero");

            // Business rule: Working days must be realistic within a month
            if (workingDays < 1 || workingDays > 31)
                throw new ArgumentException("Working days must be between 1 and 31");

            HourlyRate = hourlyRate;
            WorkingDays = workingDays;

            // Identifies employee category at runtime
            EmployeeType = "Contract";
        }

        #endregion

        #region Salary Calculations

        /// <summary>
        /// Calculates gross salary using:
        /// HourlyRate × WorkingDays × 8 hours/day
        /// </summary>
        public override decimal CalculateGrossSalary()
        {
            return HourlyRate * WorkingDays * 8;
        }

        /// <summary>
        /// Calculates deductions for contract employees (5% of gross salary).
        /// </summary>
        public override decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.05m;
        }

        #endregion
    }
}
