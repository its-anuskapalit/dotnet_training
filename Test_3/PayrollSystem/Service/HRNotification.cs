using System;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    public class HRNotificationService
    {
        public void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine("[HR] Salary processed for " + emp.Name);
        }
    }
}
