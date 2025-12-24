// namespace Oops
// {
//     public abstract class HRJobs{
//     public  abstract void GrantLeave();
//     public abstract void MarkAttendance();
// }
//     public class Employee : Manage
//     {
//         public int empId { get; set; }
//         public string? empName { get; set; }
//         public string? empRole { get; set; }
//         public void GrantLeave()
//         {
//             // Implementation of GrantLeave method
//             Console.WriteLine($"{empName} has granted leave.");
//         }
//         public void MarkAttendance()
//         {
//             // Implementation of MarkAttendance method
//             Console.WriteLine($"{empName} has marked attendance.");
//         }
//         public void Meeting()
//         {
//             // Implementation of Meeting method
//             Console.WriteLine($"{empName} is attending a meeting.");
//         }
//         public void ProjectDeadline()
//         {
//             // Implementation of ProjectDeadline method
//             Console.WriteLine($"{empName} has a project deadline approaching.");
//         }
//     }
//     public class HR : Employee, HRJobs
//     {
//         public void ProjectWork()
//         {
//             // Implementation of ProjectWork method
//             Console.WriteLine($"{empName} is working on HR projects.");
//         }
//         public void Schedule()
//         {
//             // Implementation of Schedule method
//             Console.WriteLine($"{empName} is scheduling interviews.");
//         }
//         public void Update()
//         {
//             // Implementation of Update method
//             Console.WriteLine($"{empName} is updating employee records.");
//         }
//     }
// }