using Microsoft.AspNetCore.Mvc;
using TestingMVC2.Services;

namespace TestingMVC2.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    public IActionResult GetEmployee(int id)
    {
        var employee = _service.GetEmployee(id);

        return Ok(employee);
    }
}