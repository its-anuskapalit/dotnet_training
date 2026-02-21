using NUnit.Framework;
using Moq;
using System.Collections.Generic;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void GetEmployeeCount_ReturnsCorrectCount()
    {
        var mockRepo = new Mock<IEmployeeRepository>();

        mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
        {
            new Employee{ Id = 1, Name = "Ravi", Salary = 50000 },
            new Employee{ Id = 2, Name = "Anu", Salary = 60000 }
        });

        var service = new EmployeeService(mockRepo.Object);

        int count = service.GetEmployeeCount();

        Assert.AreEqual(2, count);
    }
}
