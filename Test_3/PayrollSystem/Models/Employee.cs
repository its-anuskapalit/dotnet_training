using System;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Abstract base class that defines core properties and salary behavior
    /// for all employee types in the Payroll System.
    /// Provides validation, salary calculation template and life-cycle control.
    /// </summary>
    public abstract class Employee
    {
        #region Properties

        // Unique identifier for employee record
        public int Id { get; private set; }

        // Employee full name
        public string Name { get; private set; }

        // Department to which the employee belongs
        public string Department { get; private set; }

        // Date when employee joined the organization
        public DateTime JoinDate { get; private set; }

        // Official email address
        public string Email { get; private set; }

        // Contact phone number
        public string Phone { get; private set; }

        // Indicates if the employee is currently active in payroll
        public bool IsActive { get; private set; }

        // Holds the employee category (FullTime / Contract etc.)
        public string EmployeeType { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes common employee attributes and performs data validation.
        /// </summary>
        protected Employee(int id, string name, string dep, DateTime date, string email, string phone)
        {
            // Business rule: Employee Id must be valid primary key
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Employee id must be positive");

            // Business rule: Name is mandatory
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Employee name cannot be empty");

            // Business rule: Department is mandatory
            if (string.IsNullOrWhiteSpace(dep))
                throw new ArgumentException("Department is required");

            // Business rule: Email is mandatory
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required");

            Id = id;
            Name = name;
            Department = dep;
            JoinDate = date;
            Email = email;
            Phone = phone;

            // New employee is active by default
            IsActive = true;
        }

        #endregion

        #region Employee Life Cycle

        /// <summary>
        /// Deactivates the employee from payroll processing.
        /// </summary>
        public void Deactive()
        {
            IsActive = false;
        }

        #endregion

        #region Salary Calculation Template

        /// <summary>
        /// Calculates gross salary based on employee type.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract decimal CalculateGrossSalary();

        /// <summary>
        /// Calculates salary deductions (default 10%).
        /// Can be overridden by specific employee types.
        /// </summary>
        public virtual decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.10m;
        }

        /// <summary>
        /// Template method to compute final take-home salary.
        /// </summary>
        public decimal CalculateNetSalary()
        {
            decimal gross = CalculateGrossSalary();
            decimal deductions = CalculateDeductions(gross);
            return gross - deductions;
        }

        #endregion
    }
}
