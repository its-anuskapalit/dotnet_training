using TestingMVC.Models;

namespace TestingMVC.Repositories;

public interface IEmployeeRepository
{
    Employee GetEmployee(int id);
}