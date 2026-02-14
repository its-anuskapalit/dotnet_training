using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {

        string cs = "Server=POLLY\\SQLEXPRESS;Database=TrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        string sql = @"SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

        using SqlConnection con = new SqlConnection(cs);
        using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

        DataSet ds = new();
        adapter.Fill(ds, "Employees");

        string filePath = "Employees.xml";
        ds.WriteXml(filePath);

        Console.WriteLine($"XML file saved: {filePath}");
    }
}