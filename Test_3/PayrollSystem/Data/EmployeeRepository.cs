using System.Collections.Generic;
using PayrollSystem.Models;

namespace PayrollSystem.Data
{
    /// <summary>
    /// Repository class responsible for managing all Employee related data in-memory.
    /// Acts as a mock database layer using Dictionary collection.
    /// Provides methods to retrieve and insert employees.
    /// </summary>
    public class EmployeeRepository
    {
        #region Private Fields

        // Acts as in-memory database where Key = Employee Id and Value = Employee Object
        private Dictionary<int, Employee> _employees = new Dictionary<int, Employee>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the repository with pre-loaded employee records.
        /// This simulates existing data in a real database system.
        /// </summary>
        public EmployeeRepository()
        {
            // Adding sample FullTime and Contract employees to mimic persistent storage
            _employees.Add(1, new FullTimeEmployee(1, "Anuska", "IT", System.DateTime.Now.AddYears(-2), "a@gmail.com", "9999", 45000, 5000));
            _employees.Add(2, new FullTimeEmployee(2, "Ravi", "HR", System.DateTime.Now.AddYears(-1), "r@gmail.com", "8888", 40000, 3000));
            _employees.Add(3, new ContractEmployee(3, "Neha", "IT", System.DateTime.Now.AddMonths(-6), "n@gmail.com", "7777", 500, 20));
            _employees.Add(4, new ContractEmployee(4, "Aman", "Sales", System.DateTime.Now.AddMonths(-8), "am@gmail.com", "6666", 600, 22));
            _employees.Add(5, new FullTimeEmployee(5, "Sita", "Finance", System.DateTime.Now.AddYears(-3), "s@gmail.com", "5555", 55000, 7000));
            _employees.Add(6, new ContractEmployee(6, "Rohit", "Support", System.DateTime.Now.AddMonths(-4), "ro@gmail.com", "4444", 400, 25));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all employee records from the repository.
        /// </summary>
        /// <returns>Dictionary of all employees.</returns>
        public Dictionary<int, Employee> GetAll()
        {
            // Returning the in-memory employee database
            return _employees;
        }

        /// <summary>
        /// Adds a new employee into the repository.
        /// Prevents duplicate employee insertion using Employee Id.
        /// </summary>
        /// <param name="emp">Employee object to be added.</param>
        public void Add(Employee emp)
        {
            // Check to avoid duplicate primary key (Employee Id)
            if (!_employees.ContainsKey(emp.Id))
                _employees.Add(emp.Id, emp);
        }

        #endregion
    }
}
