using Microsoft.AspNetCore.Mvc;

namespace MySwaggerApi
{
        [ApiController]
        [Route("api/[controller]")]
        public class EmployeeController : ControllerBase
        {
            public static List<Employee> Employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "John", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Sara", Department = "HR", Salary = 45000 }
        };

            // GET
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(Employees);
            }

            // POST
            [HttpPost]
            public IActionResult AddEmployee(Employee emp)
            {
                Employees.Add(emp);

                return Ok(new
                {
                    Message = "Employee added successfully",
                    Employees
                });
            }

            // PUT
            [HttpPut("{id}")]
            public IActionResult UpdateEmployee(int id, Employee updatedEmp)
            {
                var emp = Employees.FirstOrDefault(e => e.Id == id);

                if (emp == null)
                {
                    return NotFound("Employee not found");
                }

                emp.Name = updatedEmp.Name;
                emp.Department = updatedEmp.Department;
                emp.Salary = updatedEmp.Salary;

                return Ok(new
                {
                    Message = "Employee updated successfully",
                    Employees
                });
            }
        }
}
