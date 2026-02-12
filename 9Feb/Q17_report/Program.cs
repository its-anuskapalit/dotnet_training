using System;

class Program
{
    static void Main()
    {
        PrintReport("Sales Report");
        PrintReport(title: "Inventory Report", showHeader: false);
        PrintReport("Attendance Report", copies: 3);
    }

    static void PrintReport(string title, int copies = 1, bool showHeader = true)
    {
        if (showHeader)
            Console.WriteLine("Report: " + title);

        Console.WriteLine("Copies: " + copies);
        Console.WriteLine();
    }
}
