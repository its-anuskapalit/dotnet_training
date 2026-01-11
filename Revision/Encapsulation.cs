//Encapsulation – Payroll Safety
public class Employee
{
    private decimal salary;
    public decimal Salary
    {
        get { return salary; }
        set
        {
            if(value < 0) throw new Exception("Invalid salary");
            salary=value;
        }
    }
}