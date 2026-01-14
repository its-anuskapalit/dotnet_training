using System;
using PayrollSystem.Data;
using PayrollSystem.Models;
using PayrollSystem.Services;
namespace PayrollSystem.UI
{
   
    public class MenuUI
    {
        private EmployeeRepository _empRepo;
        private PaySlipRepository _slipRepo;
        private PayrollService _payroll;

        public MenuUI(EmployeeRepository empRepo, PaySlipRepository slipRepo, PayrollService payroll)
        {
            _empRepo = empRepo;
            _slipRepo = slipRepo;
            _payroll = payroll;
        }

        public void Start()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("      Welcome to Payroll System");
            Console.WriteLine("=======================================\n");

            bool exit = false;

            while (!exit)
            {
                try
                {
                    Console.WriteLine("\nPlease choose an option:");
                    Console.WriteLine("1. Add New Employee");
                    Console.WriteLine("2. View All Employees");
                    Console.WriteLine("3. Process Payroll");
                    Console.WriteLine("4. View Payroll Summary");
                    Console.WriteLine("5. Exit Application");
                    Console.Write("\nEnter choice: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddEmployee(); break;
                        case 2: ViewEmployees(); break;
                        case 3: ProcessPayroll(); break;
                        case 4: ViewSummary(); break;
                        case 5:
                            Console.WriteLine("\nThank you for using Payroll System.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input Error: " + ex.Message);
                }
            }
        }
        private void AddEmployee()
        {
            try
            {
                Console.WriteLine("\nSelect Employee Type");
                Console.WriteLine("1. Full Time");
                Console.WriteLine("2. Contract");
                Console.Write("Choice: ");
                int type = int.Parse(Console.ReadLine());

                Console.Write("Enter Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Enter Joining Date (yyyy-mm-dd): ");
                DateTime join = DateTime.Parse(Console.ReadLine());

                if (type == 1)
                {
                    Console.Write("Enter Basic Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Bonus: ");
                    decimal bonus = decimal.Parse(Console.ReadLine());

                    _empRepo.Add(new FullTimeEmployee(id, name, dept, join, email, phone, salary, bonus));
                }
                else
                {
                    Console.Write("Enter Hourly Rate: ");
                    decimal rate = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Working Days: ");
                    int days = int.Parse(Console.ReadLine());

                    _empRepo.Add(new ContractEmployee(id, name, dept, join, email, phone, rate, days));
                }

                Console.WriteLine("\nEmployee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding employee: " + ex.Message);
            }
        }

        private void ViewEmployees()
        {
            Console.WriteLine("\n------ Employee List ------");
            foreach (var e in _empRepo.GetAll().Values)
                Console.WriteLine($"{e.Id} | {e.Name} | {e.EmployeeType} | {e.Department}");
        }

        private void ProcessPayroll()
        {
            Console.WriteLine("\nProcessing payroll...");
            foreach (var e in _empRepo.GetAll().Values)
                _payroll.Process(e);

            Console.WriteLine("Payroll processing completed successfully.");
        }

        private void ViewSummary()
        {
            Console.WriteLine("\n------ Payroll Summary ------");
            foreach (var s in _slipRepo.GetAll())
                Console.WriteLine($"{s.EmployeeName} | Gross: {s.GrossSalary} | Net: {s.NetSalary}");
        }
    }
}
