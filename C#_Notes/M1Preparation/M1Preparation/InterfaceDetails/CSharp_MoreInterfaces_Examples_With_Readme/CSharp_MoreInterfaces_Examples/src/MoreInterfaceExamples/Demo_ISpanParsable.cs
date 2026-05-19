using System;

namespace MoreInterfaceExamples;

public static class Demo_ISpanParsable
{
    public static void Run()
    {
        Console.WriteLine("---- 14) ISpanParsable<TSelf> Demo ----");

        ReadOnlySpan<char> input = "EMP-555".AsSpan();
        if (EmployeeId.TryParse(input, null, out var id))
            Console.WriteLine($"Parsed from span: {id.Value}");
        else
            Console.WriteLine("Failed to parse from span.");

        Console.WriteLine();
    }

    private readonly record struct EmployeeId(int Value) : ISpanParsable<EmployeeId>
    {
        public static EmployeeId Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        public static EmployeeId Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            if (!TryParse(s, provider, out var result))
                throw new FormatException("Invalid EmployeeId format.");
            return result;
        }

        public static bool TryParse(string? s, IFormatProvider? provider, out EmployeeId result) =>
            TryParse(s.AsSpan(), provider, out result);

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out EmployeeId result)
        {
            result = default;
            if (s.Length < 6) return false;

            if (!(char.ToUpperInvariant(s[0]) == 'E' &&
                  char.ToUpperInvariant(s[1]) == 'M' &&
                  char.ToUpperInvariant(s[2]) == 'P' &&
                  s[3] == '-'))
                return false;

            var numSpan = s.Slice(4);
            if (!int.TryParse(numSpan, out int value)) return false;

            result = new EmployeeId(value);
            return true;
        }
    }
}
