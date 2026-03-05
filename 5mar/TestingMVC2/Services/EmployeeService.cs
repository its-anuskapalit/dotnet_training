using TestingMVC2.Models;
using TestingMVC2.Repositories;

namespace TestingMVC2.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public Employee GetEmployee(int id)
    {
        if (id <= 0)
            throw new Exception("Invalid Employee Id");

        return _repo.GetEmployee(id);
    }
}