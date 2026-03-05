using Moq;
using Xunit;
using TestingMVC.Models;
using TestingMVC.Repositories;
using TestingMVC.Services;

namespace TestingMVC.Tests.ServicesTests;

public class EmployeeServiceTests
{
    private readonly Mock<IEmployeeRepository> repoMock;
    private readonly EmployeeService service;
    public EmployeeServiceTests()
    {
        repoMock = new Mock<IEmployeeRepository>();
        service = new EmployeeService(repoMock.Object);
    }
    [Fact]
    public void GetEmployee_ReturnsEmployee()
    {
        var emp = new Employee { Id = 1, Name = "John" };
        repoMock.Setup(r => r.GetEmployee(1)).Returns(emp);
        var result = service.GetEmployee(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void GetEmployee_ThrowsException()
    {
        Assert.Throws<Exception>(() => service.GetEmployee(0));
    }
}