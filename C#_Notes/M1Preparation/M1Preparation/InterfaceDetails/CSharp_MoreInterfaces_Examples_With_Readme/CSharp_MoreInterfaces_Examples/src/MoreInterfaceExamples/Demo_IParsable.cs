using System;

namespace MoreInterfaceExamples;

public static class Demo_IParsable
{
    public static void Run()
    {
        Console.WriteLine("---- 13) IParsable<TSelf> Demo ----");

        var emp = EmployeeId.Parse("EMP-102", null);
        Console.WriteLine($"Parsed: {emp.Value}");

        if (EmployeeId.TryParse("EMP-XYZ", null, out var _))
            Console.WriteLine("TryParse success (unexpected)");
        else
            Console.WriteLine("TryParse failed for EMP-XYZ");

        Console.WriteLine();
    }

    private readonly record struct EmployeeId(int Value) : IParsable<EmployeeId>
    {
        public static EmployeeId Parse(string s, IFormatProvider? provider)
        {
            if (!TryParse(s, provider, out var result))
                throw new FormatException("Invalid EmployeeId format. Expected EMP-<number>.");
            return result;
        }

        public static bool TryParse(string? s, IFormatProvider? provider, out EmployeeId result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s)) return false;
            if (!s.StartsWith("EMP-", StringComparison.OrdinalIgnoreCase)) return false;

            var numPart = s.Substring(4);
            if (!int.TryParse(numPart, out int value)) return false;

            result = new EmployeeId(value);
            return true;
        }
    }
}
