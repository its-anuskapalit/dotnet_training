using System;
namespace PayrollSystem.Models
{
    public class PaySlip
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeType { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime GeneratedOn { get; set; }
    }
}
