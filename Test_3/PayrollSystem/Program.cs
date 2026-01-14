using PayrollSystem.Data;
using PayrollSystem.Services;
using PayrollSystem.UI;

class Program
{
    static void Main()
    {
        EmployeeRepository empRepo = new EmployeeRepository();
        PaySlipRepository slipRepo = new PaySlipRepository();

        PayrollService payroll = new PayrollService(slipRepo);

        HRNotificationService hr = new HRNotificationService();
        FinanceNotificationService finance = new FinanceNotificationService();

        payroll.OnSalaryProcessed += hr.Notify;
        payroll.OnSalaryProcessed += finance.Notify;

        MenuUI menu = new MenuUI(empRepo, slipRepo, payroll);
        menu.Start();
    }
}
