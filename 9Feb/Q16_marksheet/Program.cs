using System;
class Program
{
    static void Main()
    {
        int[] marks = { 78, 65, 40, 88, 56 };
        CalculateResult(marks, out int total, out double avg, out string result);
        Console.WriteLine("Total: " + total);
        Console.WriteLine("Average: " + avg);
        Console.WriteLine("Result: " + result);
    }

    static void CalculateResult(int[] marks, out int total, out double avg, out string result)
    {
        total = 0;
        bool pass = true;
        foreach (int m in marks)
        {
            total += m;
            if (m < 35)
                pass = false;
        }
        avg = total / (double)marks.Length;
        result = pass ? "Pass" : "Fail";
    }
}
