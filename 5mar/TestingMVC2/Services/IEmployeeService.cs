using TestingMVC2.Models;
namespace TestingMVC2.Services;

public interface IEmployeeService
{
    Employee GetEmployee(int id);
}