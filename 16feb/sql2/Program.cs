// //==================1=========================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         string sql = "SELECT * FROM Students";

//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

//         DataTable Students = new DataTable();
//         adapter.Fill(Students);

//         var activeNames = Students.AsEnumerable()
//             .Where(r => r.Field<bool>("IsActive"))
//             .Select(r => r.Field<string>("FullName"))
//             .ToList();

//         activeNames.ForEach(Console.WriteLine);
//     }
// }
////output
// Aarav Sharma
// Diya Iyer
// Kabir Nair
// Meera Singh
// Rohan Verma
// Vikram Rao

// // ==================2=========================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
//         string sql = "SELECT * FROM Students";
//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//         DataTable Students = new DataTable();
//         adapter.Fill(Students);

//         var toppers = Students.AsEnumerable()
//     .Where(r => r.Field<int>("Marks") >= 80)
//     .Select(r => new
//     {
//         Id = r.Field<int>("StudentId"),
//         Name = r.Field<string>("FullName"),
//         Marks = r.Field<int>("Marks")
//     })
//     .ToList();

//         foreach (var s in toppers)
//             Console.WriteLine($"{s.Id} | {s.Name} | {s.Marks}");
//     }
// }
// //output
// // 1 | Aarav Sharma | 92
// // 2 | Diya Iyer | 81
// // 4 | Meera Singh | 88
// // 7 | Vikram Rao | 95

////==================3=========================

// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
//         string sql = "SELECT * FROM Students";
//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//         DataTable Students = new DataTable();
//         adapter.Fill(Students);
//         string city = "Pune";

//         var puneStudents = Students.AsEnumerable()
//             .Where(r => r.Field<string>("City") == city)
//             .Select(r => r.Field<string>("FullName"))
//             .ToList();

//         Console.WriteLine("Students in Pune:");
//         puneStudents.ForEach(Console.WriteLine);

//     }
// }
// //Output
// // Students in Pune:
// // Meera Singh

////==================4=========================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
//         string sql = "SELECT * FROM Students";
//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//         DataTable Students = new DataTable();
//         adapter.Fill(Students);
//         string city = "Pune";

//         var puneStudents = Students.AsEnumerable()
//             .Where(r => r.Field<string>("City") == city)
//             .Select(r => r.Field<string>("FullName"))
//             .ToList();
//         Console.WriteLine("Students in Pune:");
//         puneStudents.ForEach(Console.WriteLine);
//     }
// }

//===========5=================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
//         string sql = "SELECT * FROM Students";
//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//         DataTable Students = new DataTable();
//         adapter.Fill(Students);
//         string city = "Pune";

//         var sorted = Students.AsEnumerable()
//     .OrderByDescending(r => r.Field<int>("Marks"))
//     .ThenBy(r => r.Field<string>("FullName"))
//     .Select(r => new
//     {
//         Name = r.Field<string>("FullName"),
//         Marks = r.Field<int>("Marks")
//     })
//     .ToList();

//         Console.WriteLine("Sorted by Marks desc, then Name:");
//         foreach (var s in sorted)
//             Console.WriteLine($"{s.Name} - {s.Marks}");

//     }
// }
// // Sorted by Marks desc, then Name:
// // Vikram Rao - 95
// // Aarav Sharma - 92
// // Meera Singh - 88
// // Diya Iyer - 81
// // Rohan Verma - 74
// // Kabir Nair - 67
// // Isha Patel - 59

////=============6====================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
//         string sql = "SELECT * FROM Students";
//         using SqlConnection con = new SqlConnection(cs);
//         using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
//         DataTable Students = new DataTable();
//         adapter.Fill(Students);
//         var byCity = Students.AsEnumerable()
//     .GroupBy(r => r.Field<string>("City"))
//     .Select(g => new
//     {
//         City = g.Key,
//         Count = g.Count(),
//         AvgMarks = (int)g.Average(x => x.Field<int>("Marks"))
//     })
//     .OrderByDescending(x => x.AvgMarks)
//     .ToList();

//         foreach (var g in byCity)
//             Console.WriteLine($"{g.City} | Count={g.Count} | AvgMarks={g.AvgMarks}");
//     }
// }

// // Mumbai | Count=1 | AvgMarks=95
// // Chennai | Count=1 | AvgMarks=92
// // Pune | Count=1 | AvgMarks=88
// // Bengaluru | Count=1 | AvgMarks=81
// // Delhi | Count=1 | AvgMarks=74
// // Hyderabad | Count=1 | AvgMarks=67
// // Ahmedabad | Count=1 | AvgMarks=59

////============= 7 ====================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;
// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         DataTable students = new DataTable();
//         DataTable enrollments = new DataTable();
//         DataTable courses = new DataTable();

//         using (SqlConnection con = new SqlConnection(cs))
//         {
//             con.Open();

//             using (var da1 = new SqlDataAdapter("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
//                 da1.Fill(students);

//             using (var da2 = new SqlDataAdapter("SELECT StudentId, CourseId FROM Enrollments", con))
//                 da2.Fill(enrollments);

//             using (var da3 = new SqlDataAdapter("SELECT CourseId, CourseName FROM Courses", con))
//                 da3.Fill(courses);
//         }
//         Console.WriteLine("Data Loaded Successfully");
//     }
// }
// //Data Loaded Successfully

// //=============== 8 =============================
// using System;
// using System.Data;
// using System.Linq;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         DataTable students = new DataTable();
//         DataTable enrollments = new DataTable();
//         DataTable courses = new DataTable();

//         using (SqlConnection con = new SqlConnection(cs))
//         {
//             con.Open();

//             new SqlDataAdapter("SELECT * FROM Students", con).Fill(students);
//             new SqlDataAdapter("SELECT * FROM Enrollments", con).Fill(enrollments);
//             new SqlDataAdapter("SELECT * FROM Courses", con).Fill(courses);
//         }

//         var report =
//             from s in students.AsEnumerable()
//             join e in enrollments.AsEnumerable()
//                 on s.Field<int>("StudentId") equals e.Field<int>("StudentId")
//             join c in courses.AsEnumerable()
//                 on e.Field<int>("CourseId") equals c.Field<int>("CourseId")
//             where s.Field<bool>("IsActive")
//             select new
//             {
//                 Student = s.Field<string>("FullName"),
//                 City = s.Field<string>("City"),
//                 Marks = s.Field<int>("Marks"),
//                 Course = c.Field<string>("CourseName")
//             };

//         foreach (var row in report)
//             Console.WriteLine($"{row.Student} | {row.City} | {row.Marks} | {row.Course}");
//     }
// }
// // Aarav Sharma | Chennai | 92 | ADO.NET
// // Aarav Sharma | Chennai | 92 | LINQ
// // Diya Iyer | Bengaluru | 81 | ADO.NET
// // Diya Iyer | Bengaluru | 81 | SQL Server
// // Kabir Nair | Hyderabad | 67 | C# Fundamentals
// // Meera Singh | Pune | 88 | LINQ
// // Rohan Verma | Delhi | 74 | SQL Server
// // Vikram Rao | Mumbai | 95 | ADO.NET

// //=============== 9 =============================
using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = "Server=POLLY\\SQLEXPRESS;Database=ItTechGenieTrainingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        string sql = "SELECT Marks FROM Students";

        using SqlConnection con = new SqlConnection(cs);
        using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

        DataTable students = new DataTable();
        adapter.Fill(students);

        // if (students.Rows.Count > 0)
        // {
        //     var rows = students.AsEnumerable();

        //     int maxMarks = rows.Max(r => r.Field<int>("Marks"));
        //     int minMarks = rows.Min(r => r.Field<int>("Marks"));
        //     double avgMarks = rows.Average(r => r.Field<int>("Marks"));
        //     int sumMarks = rows.Sum(r => r.Field<int>("Marks"));

        //     Console.WriteLine($"Max = {maxMarks}");
        //     Console.WriteLine($"Min = {minMarks}");
        //     Console.WriteLine($"Avg = {avgMarks:0.00}");
        //     Console.WriteLine($"Sum = {sumMarks}");
        // }
        // else
        // {
        //     Console.WriteLine("No data found.");
        // }
        var rows = students.AsEnumerable();

        bool anyInactive = rows.Any(r => r.Field<bool>("IsActive") == false);
        bool allHaveMarks = rows.All(r => r.Field<int>("Marks") >= 0);

        var firstTopper = rows
            .Where(r => r.Field<int>("Marks") >= 90)
            .Select(r => r.Field<string>("FullName"))
            .FirstOrDefault();

        Console.WriteLine("Any inactive? " + anyInactive);
        Console.WriteLine("All have marks? " + allHaveMarks);
        Console.WriteLine("First topper: " + firstTopper);
    }
}
