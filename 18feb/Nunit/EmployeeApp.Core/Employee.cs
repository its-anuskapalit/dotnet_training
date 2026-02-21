using System.Collections.Generic;using System.Collections.Generic;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}

public interface IEmployeeRepository
{
    List<Employee> GetAll();
}

public class EmployeeService
{
    private readonly IEmployeeRepository repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    public int GetEmployeeCount()
    {
        return repository.GetAll().Count;
    }
}