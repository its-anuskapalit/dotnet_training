using TestingMVC.Models;
using TestingMVC.Repositories;

namespace TestingMVC.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public Employee GetEmployee(int id)
    {
        if (id <= 0)
        {
            throw new Exception("Invalid Employee Id");
        }

        return _repo.GetEmployee(id);
    }
}