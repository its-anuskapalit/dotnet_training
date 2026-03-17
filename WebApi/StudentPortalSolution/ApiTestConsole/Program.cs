using System.Net.Http.Json;
var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5137/");
var students = await client.GetFromJsonAsync<List<Student>>("api/Students");
if (students != null)
{
    foreach (var s in students)
    {
        Console.WriteLine($"{s.StudentId} - {s.FullName} - {s.Email}");
    }
}
else
{
    Console.WriteLine("No data returned from API.");
}
public class Student
{
    public int StudentId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}