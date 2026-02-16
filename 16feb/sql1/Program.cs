using System;
using System.Data;
using Microsoft.Data.SqlClient;
class Program
{
    static string cs = "Server=POLLY\\SQLEXPRESS;Database=TrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
    static void Main()
    {
        DataSet ds = new DataSet();
        using SqlConnection con = new SqlConnection(cs);
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
        using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.Fill(ds, "Employees");
        Console.WriteLine("Initial Data:");
        // PrintData(ds);
        // InsertEmployee(ds);
        // UpdateEmployee(ds);
        // //DeleteEmployee(ds);
        // adapter.Update(ds, "Employees");
        // Console.WriteLine("\nAfter Database Update:");
        // ds.Tables["Employees"].Clear();
        // adapter.Fill(ds, "Employees");
        // PrintData(ds);
        FindRowLinq(ds);
    }
    static void InsertEmployee(DataSet ds)
    {
        DataRow newRow = ds.Tables["Employees"].NewRow();
        // newRow["FullName"] = "Aaryan";
        // newRow["Department"] = "CEO";
        // newRow["Salary"] = 100000;
        // ds.Tables["Employees"].Rows.Add(newRow);
        // newRow["FullName"] = "Ravi";
        // newRow["Department"]= "Finance";
        // newRow["Salary"] = 4500.0;
        // ds.Tables["Employees"].Rows.Add(newRow);
        newRow["FullName"] = "Anuska Palit";
        newRow["Department"] = "IT";
        newRow["Salary"] = 1000.50;
        ds.Tables["Employees"].Rows.Add(newRow);

    }
    static void UpdateEmployee(DataSet ds)
    {
        ds.Tables["Employees"].Rows[0]["Salary"] = 90000;
    }
    static void DeleteEmployee(DataSet ds)
    {
        ds.Tables["Employees"].Rows[7].Delete();
    }
    static void PrintData(DataSet ds)
    {
        foreach (DataRow row in ds.Tables["Employees"].Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                Console.WriteLine($"{row["EmployeeId"]} | {row["FullName"]} | {row["Department"]} | {row["Salary"]}");
            }
        }
    }
    static void FindRowLinq(DataSet ds)
    {
        var row = ds.Tables["Employees"].AsEnumerable().FirstOrDefault(r => (int)r["EmployeeId"] == 5);
        if (row != null)
            Console.WriteLine($"Found: {row["FullName"]}");
        else
            Console.WriteLine("Not Found");
    }
}
