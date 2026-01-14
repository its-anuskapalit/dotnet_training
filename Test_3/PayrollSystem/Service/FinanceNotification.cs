using System;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    public class FinanceNotificationService
    {
        public void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine("[Finance] Payslip generated for " + emp.Name);
        }
    }
}
