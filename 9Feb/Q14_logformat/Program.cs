using System;
using System.Diagnostics;
using System.Text;
class Program
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        string log1 = "";
        sw.Start();
        for (int i = 0; i < 10000; i++)
            log1 += "Log line " + i + "\n";
        sw.Stop();
        Console.WriteLine("String (+) Time: " + sw.ElapsedMilliseconds);
        sw.Reset();
        StringBuilder sb = new StringBuilder();
        sw.Start();
        for (int i = 0; i < 10000; i++)
            sb.Append("Log line " + i + "\n");
        sw.Stop();
        Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds);
    }
}
