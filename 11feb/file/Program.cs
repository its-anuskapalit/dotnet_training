using System;
using System.IO;
try
{
    string path = Path.Combine(AppContext.BaseDirectory, "data.txt");

    if (!File.Exists(path))
    {
        Console.WriteLine("File not found.");
        return;
    }

    string text = File.ReadAllText(path);
    Console.WriteLine(text);
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine("Permission issue: " + ex.Message);
}
catch (IOException ex)
{
    Console.WriteLine("File I/O issue: " + ex.Message);
}