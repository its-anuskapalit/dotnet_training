using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
namespace ProcessInfo{
class Program
{
    static void Main()
    {
        var processesList = new List<ProcessInfo>();
        Process[] allProcesses = Process.GetProcesses();
        foreach (Process p in allProcesses)
        {
            
                processesList.Add(new ProcessInfo
                {
                    Id = p.Id,
                    Name = p.ProcessName,
                    MemoryUsageKB = p.PrivateMemorySize64 / 1024,
                });
        
        }
        var options = new JsonSerializerOptions { WriteIndented = true }; 
        string jsonOutput = JsonSerializer.Serialize(processesList, options);
        Console.WriteLine(jsonOutput);
    }
}
public class ProcessInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long MemoryUsageKB { get; set; }
}
}