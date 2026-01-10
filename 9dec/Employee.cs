using System;
class Employee
{
    int EmpId;
    int Salary;
    string? Name;
    Employee(int empId, int Salary, string name)
    {
        EmpId = empId;
        Salary = Salary;
        Name = name;
    }
    public void Display()
    {
        Console.Writline($"This Id is {EmpId} with salary {Salary} and Name {Name}");
    }
}
class Program
{
    public void Main()
    {
        Employee ob = new Employee(12,12000,Anuska);
        ob.Display();
   
    }
}