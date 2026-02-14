using Microsoft.Data.SqlClient;
using System;
class Program
{
    static void Main()
    {
        string cs = "Server=POLLY\\SQLEXPRESS;Database=TrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();

            // ---------------- INSERT ----------------
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            string insertSql = @"INSERT INTO dbo.Employees (FullName, Department, Salary) 
                                 VALUES (@name, @dept, @salary)";

            using (SqlCommand cmd = new SqlCommand(insertSql, con))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@dept", System.Data.SqlDbType.NVarChar, 50).Value = dept;
                //cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.Add("@salary", System.Data.SqlDbType.Decimal).Value = salary;

                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee Inserted Successfully\n");
            }

            // ---------------- UPDATE ----------------
            Console.Write("Enter EmployeeId to Update Salary: ");
            int updateId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Salary: ");
            decimal newSalary = decimal.Parse(Console.ReadLine());

            string updateSql = "UPDATE dbo.Employees SET Salary = @salary WHERE EmployeeId = @id";

            using (SqlCommand cmd = new SqlCommand(updateSql, con))
            {
                cmd.Parameters.Add("@salary", System.Data.SqlDbType.Decimal).Value = newSalary;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = updateId;

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Salary Updated\n" : "Employee Not Found\n");
            }

            // ---------------- COUNT (ExecuteScalar) ----------------
            string countSql = "SELECT COUNT(*) FROM dbo.Employees";

            using (SqlCommand cmd = new SqlCommand(countSql, con))
            {
                int total = (int)cmd.ExecuteScalar();
                Console.WriteLine($"Total Employees: {total}\n");
            }

            // ---------------- SELECT ----------------
            string selectSql = @"SELECT EmployeeId, FullName, Department, Salary 
                                 FROM dbo.Employees ORDER BY EmployeeId";

            using (SqlCommand cmd = new SqlCommand(selectSql, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("Employee List:\n");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmployeeId"]} | {reader["FullName"]} | {reader["Department"]} | {reader["Salary"]}");
                }
            }

            // ---------------- DELETE ----------------
            Console.Write("\nEnter EmployeeId to Delete: ");
            int deleteId = int.Parse(Console.ReadLine());

            string deleteSql = "DELETE FROM dbo.Employees WHERE EmployeeId = @id";

            using (SqlCommand cmd = new SqlCommand(deleteSql, con))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = deleteId;

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Employee Deleted" : "Employee Not Found");
            }

            con.Close();
        }
    }
}
