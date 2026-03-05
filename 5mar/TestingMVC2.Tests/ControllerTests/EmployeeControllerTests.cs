using Xunit;
using Moq;
using TestingMVC2.Controllers;
using TestingMVC2.Models;
using TestingMVC2.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestingMVC2.Tests.ControllerTests;

public class EmployeeControllerTests
{
    private readonly Mock<IEmployeeService> serviceMock;
    private readonly EmployeeController controller;
    public EmployeeControllerTests()
    {
        serviceMock = new Mock<IEmployeeService>();
        controller = new EmployeeController(serviceMock.Object);
    }
    [Fact]
    public void GetEmployee_ReturnsEmployee()
    {
        var emp = new Employee { Id = 1, Name = "John" };
        serviceMock.Setup(s => s.GetEmployee(1)).Returns(emp);
        var result = controller.GetEmployee(1);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var employee = Assert.IsType<Employee>(okResult.Value);
        Assert.Equal(1, employee.Id);
    }
    [Fact]
    public void GetEmployee_ThrowsException()
    {
        serviceMock.Setup(s => s.GetEmployee(0))
                   .Throws(new Exception("Invalid Id"));
        Assert.Throws<Exception>(() => controller.GetEmployee(0));
    }
}