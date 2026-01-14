using System;
using PayrollSystem.Models;
using PayrollSystem.Data;

namespace PayrollSystem.Services
{
    public delegate void SalaryProcessedHandler(Employee emp, PaySlip slip);
    public class PayrollService
    {
        private PaySlipRepository _repo;
        public SalaryProcessedHandler OnSalaryProcessed;

        public PayrollService(PaySlipRepository repo)
        {
            _repo = repo;
        }
        public void Process(Employee emp)
        {
            try
            {
                decimal gross = emp.CalculateGrossSalary();
                decimal deductions = emp.CalculateDeductions(gross);
                decimal net = emp.CalculateNetSalary();
                PaySlip slip = new PaySlip
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.Name,
                    EmployeeType = emp.EmployeeType,
                    GrossSalary = gross,
                    Deductions = deductions,
                    NetSalary = net,
                    GeneratedOn = DateTime.Now
                };

                _repo.Add(slip);
                OnSalaryProcessed?.Invoke(emp, slip);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Payroll Error: " + ex.Message);
            }
        }
    }
}
