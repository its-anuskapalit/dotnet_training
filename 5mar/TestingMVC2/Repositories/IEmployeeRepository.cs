using TestingMVC2.Models;

namespace TestingMVC2.Repositories;

public interface IEmployeeRepository
{
    Employee GetEmployee(int id);
}